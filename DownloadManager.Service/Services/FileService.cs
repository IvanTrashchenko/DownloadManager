using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using DownloadManager.Core.Enums;
using DownloadManager.Data.Dal.Contract.Dto;
using DownloadManager.Data.Dal.Contract.Repositories;
using DownloadManager.Service.Contract;
using DownloadManager.Service.Contract.Models.Input;
using DownloadManager.Service.Contract.Models.Output;
using DownloadManager.Service.Models.Output;
using File = System.IO.File;
using DownloadManager.Service.Models.Input;

namespace DownloadManager.Service
{
    public class FileService : IFileService
    {
        #region Private fields

        private readonly HttpClient _client;

        private static string _numberPattern = " ({0})";

        private readonly IFileRepository _fileRepository;

        private readonly IUserRepository _userRepository;

        private readonly ILogger _logger;

        private static int _workNumber = 0;

        #endregion

        #region ctor

        public FileService(IFileRepository fileRepository, IUserRepository userRepository, ILogger logger = null)
        {
            _fileRepository = fileRepository ?? throw new ArgumentNullException(nameof(fileRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _logger = logger;
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Origin", "http://localhost:4200");
        }

        #endregion

        #region Public methods

        public IFileViewModel GetFileInfoById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException($"Invalid FileId {id}.");
            }

            var resultFile = _fileRepository.GetById(id);

            if (resultFile == null)
            {
                throw new InvalidOperationException($"File with id {id} was not found.");
            }

            return Map(resultFile);
        }

        public void DownloadFile(IFileDownloadModel fileDownloadModel)
        {
            if (fileDownloadModel == null)
            {
                throw new ArgumentNullException(nameof(fileDownloadModel));
            }

            if (string.IsNullOrWhiteSpace(fileDownloadModel.FileName))
            {
                throw new ArgumentNullException(nameof(fileDownloadModel.FileName));
            }

            Regex containsABadCharacter = new Regex("["
                                                    + Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars())) + "]");

            if (containsABadCharacter.IsMatch(fileDownloadModel.FileName))
            {
                throw new ArgumentException($"File name contains invalid characters.");
            }

            if (string.IsNullOrWhiteSpace(fileDownloadModel.FileDownloadDirectory))
            {
                throw new ArgumentNullException(nameof(fileDownloadModel.FileDownloadDirectory));
            }

            if (string.IsNullOrWhiteSpace(fileDownloadModel.Url))
            {
                throw new ArgumentNullException(nameof(fileDownloadModel.Url));
            }

            if (fileDownloadModel.UserId < 1)
            {
                throw new ArgumentException($"Invalid UserId {fileDownloadModel.UserId}.");
            }

            var user = _userRepository.GetById(fileDownloadModel.UserId);

            if (user == null)
            {
                throw new ArgumentException($"User with id {fileDownloadModel.UserId} was not found.");
            }

            switch (fileDownloadModel.FileDownloadMethod)
            {
                case DownloadMethod.BeginInvoke:
                    new Action<object>(DownloadFileInner).BeginInvoke(fileDownloadModel, null, null);
                    break;
                case DownloadMethod.Thread:
                    new Thread(DownloadFileInner).Start(fileDownloadModel);
                    break;
                case DownloadMethod.ThreadPool:
                    ThreadPool.QueueUserWorkItem(DownloadFileInner, fileDownloadModel);
                    break;
                case DownloadMethod.BackgroundWorker:
                    BackgroundWorker worker = new BackgroundWorker();
                    worker.DoWork += (sender, args) => DownloadFileInner(args.Argument);
                    worker.RunWorkerAsync(fileDownloadModel);
                    break;
                case DownloadMethod.Task:
                    Task.Factory.StartNew(DownloadFileInner, fileDownloadModel);
                    break;
                default:
                    throw new NotSupportedException($"DownloadMethod {fileDownloadModel.FileDownloadMethod} is not supported.");
            }
        }

        public void UpdateFileInfo(int id, IFileUpdateModel fileUpdateModel)
        {
            if (id < 1)
            {
                throw new ArgumentException($"Invalid FileId {id}.");
            }

            if (fileUpdateModel == null)
            {
                throw new ArgumentNullException(nameof(fileUpdateModel));
            }

            var file = _fileRepository.GetById(id);

            if (file == null)
            {
                throw new InvalidOperationException($"File with id {id} was not found.");
            }

            if (!string.IsNullOrWhiteSpace(fileUpdateModel.FileName))
            {
                file.FileName = fileUpdateModel.FileName;
            }

            if (!string.IsNullOrWhiteSpace(fileUpdateModel.FileDownloadDirectory))
            {
                file.FileDownloadDirectory = fileUpdateModel.FileDownloadDirectory;
            }

            if (fileUpdateModel.FileDownloadMethod != null)
            {
                //check if valid
                file.FileDownloadMethod = fileUpdateModel.FileDownloadMethod.Value;
            }

            if (fileUpdateModel.FileDownloadTime != null)
            {
                file.FileDownloadTime = fileUpdateModel.FileDownloadTime.Value;
            }

            if (fileUpdateModel.UserId != null)
            {
                if (fileUpdateModel.UserId.Value < 1)
                {
                    throw new ArgumentException($"Invalid UserId {fileUpdateModel.UserId}.");
                }

                var user = _userRepository.GetById(fileUpdateModel.UserId.Value);

                if (user == null)
                {
                    throw new ArgumentException($"User with id {fileUpdateModel.UserId.Value} was not found.");
                }

                file.UserId = fileUpdateModel.UserId.Value;
            }

            _fileRepository.Update(file);
        }

        public IFileReportsPageModel GetFiltered(IFileFilterModel filterModel)
        {
            if (filterModel == null)
            {
                filterModel = new FileFilterModel();
            }

            return Map(_fileRepository.GetFiltered(Map(filterModel)));
        }

        #endregion

        #region Private methods

        private void DownloadFileInner(object state)
        {
            int currentWorkNumber = Interlocked.Increment(ref _workNumber);

            var tId = Thread.CurrentThread.ManagedThreadId;

            string startMessage =
                $"{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff")}: Work {currentWorkNumber} - TId {tId} - Downloading has started." +
                Environment.NewLine;

            if (_logger != null)
            {
                _logger.Log(startMessage);
            }

            try
            {
                var fileDownloadModel = (IFileDownloadModel)state;

                var response = _client.GetAsync(fileDownloadModel.Url).GetAwaiter().GetResult();

                var ext = MimeTypes.MimeTypeMap.GetExtension(response.Content.Headers.ContentType.MediaType);

                string path;

                lock (this)
                {
                    path = NextAvailableFilename(Path.Combine(fileDownloadModel.FileDownloadDirectory, $"{fileDownloadModel.FileName}{ext}"));

                    using (var fileStream = File.Open(path, FileMode.CreateNew, FileAccess.Write, FileShare.Read))
                    {
                        response.Content.CopyToAsync(fileStream).GetAwaiter().GetResult();
                    }
                }

                var finalName = Path.GetFileName(path);

                var endTime = DateTime.UtcNow;

                _fileRepository.Add(new FileDto()
                {
                    FileName = finalName,
                    FileDownloadDirectory = fileDownloadModel.FileDownloadDirectory,
                    FileDownloadMethod = fileDownloadModel.FileDownloadMethod,
                    FileDownloadTime = endTime,
                    UserId = fileDownloadModel.UserId
                });

                string endMessage = $"{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff")}: Work {currentWorkNumber} - TId {tId} - Downloading was successful." +
                                    Environment.NewLine;

                if (_logger != null)
                {
                    _logger.Log(endMessage);
                }
            }
            catch (Exception ex)
            {
                string exMessage =
                    $"{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff")}: Work {currentWorkNumber} - TId {tId} - Downloading terminated. Exception: {ex.Message}" +
                    Environment.NewLine;

                if (_logger != null)
                {
                    _logger.Log(exMessage);
                }
            }
        }

        #region NextAvailableFilename methods

        private static string NextAvailableFilename(string path)
        {
            // Short-cut if already available
            if (!File.Exists(path))
                return path;

            // If path has extension then insert the number pattern just before the extension and return next filename
            if (Path.HasExtension(path))
                return GetNextFilename(path.Insert(path.LastIndexOf(Path.GetExtension(path)), _numberPattern));

            // Otherwise just append the pattern to the path and return next filename
            return GetNextFilename(path + _numberPattern);
        }

        private static string GetNextFilename(string pattern)
        {
            string tmp = string.Format(pattern, 1);
            if (tmp == pattern)
                throw new ArgumentException("The pattern must include an index place-holder");

            if (!File.Exists(tmp))
                return tmp; // short-circuit if no matches

            int min = 1, max = 2; // min is inclusive, max is exclusive/untested

            while (File.Exists(string.Format(pattern, max)))
            {
                min = max;
                max *= 2;
            }

            while (max != min + 1)
            {
                int pivot = (max + min) / 2;
                if (File.Exists(string.Format(pattern, pivot)))
                    min = pivot;
                else
                    max = pivot;
            }

            return string.Format(pattern, max);
        }

        #endregion

        #region Mapping methods

        private IFileViewModel Map(DownloadManager.Domain.Entities.File file) =>
            new FileViewModel()
            {
                FileId = file.FileId,
                FileName = file.FileName,
                FileDownloadDirectory = file.FileDownloadDirectory,
                FileDownloadMethod = file.FileDownloadMethod,
                FileDownloadTime = file.FileDownloadTime,
                UserId = file.UserId
            };

        private FileFilterDto Map(IFileFilterModel filterModel) =>
            new FileFilterDto()
            {
                FileName = filterModel.FileName,
                FileDownloadDirectory = filterModel.FileDownloadDirectory,
                FileId = filterModel.FileId,
                FileDownloadMethod = filterModel.FileDownloadMethod,
                FileDownloadTimeStart = filterModel.FileDownloadTimeStart,
                FileDownloadTimeEnd = filterModel.FileDownloadTimeEnd,
                Username = filterModel.Username
            };

        private IFileReportModel Map(ReportDto dto) =>
            new FileReportModel()
            {
                FileId = dto.FileId,
                FileDownloadDirectory = dto.FileDownloadDirectory,
                FileDownloadMethod = dto.FileDownloadMethod,
                FileDownloadTime = dto.FileDownloadTime,
                FileName = dto.FileName,
                Username = dto.Username
            };

        private IFileReportsPageModel Map(ReportsPageDto dto)
        {
            return new FileReportsPageModel
            {
                Total = dto.Total,
                Items = dto.Items?.Select(Map)
            };
        }

        #endregion

        #endregion
    }
}
