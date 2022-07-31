using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using DownloadManager.Data.Dal.Contract.Dto;
using DownloadManager.Data.Dal.Contract.Repositories;
using DownloadManager.Service.Contract;
using DownloadManager.Service.Contract.Models.Input;
using DownloadManager.Service.Contract.Models.Output;
using DownloadManager.Service.Models.Output;
using File = System.IO.File;

namespace DownloadManager.Service
{
    public class FileService : IFileService
    {
        #region Private fields
        
        private readonly HttpClient _client;

        private static string _numberPattern = " ({0})";

        private readonly IFileRepository _fileRepository;

        #endregion

        #region ctor

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository ?? throw new ArgumentNullException(nameof(fileRepository));
            _client = new HttpClient();
        }

        #endregion

        #region Public methods

        public IFileViewModel GetFileInfoById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return Map(_fileRepository.GetById(id));
        }

        public void DownloadFile(IFileDownloadModel fileDownloadModel)
        {
            if (fileDownloadModel == null)
            {
                throw new ArgumentNullException(nameof(fileDownloadModel));
            }

            if (fileDownloadModel.FileName == null)
            {
                throw new ArgumentNullException(nameof(fileDownloadModel.FileName));
            }

            if (fileDownloadModel.FileDownloadDirectory == null)
            {
                throw new ArgumentNullException(nameof(fileDownloadModel.FileDownloadDirectory));
            }

            if (fileDownloadModel.Url == null)
            {
                throw new ArgumentNullException(nameof(fileDownloadModel.Url));
            }

            if (fileDownloadModel.UserId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(fileDownloadModel.UserId));
            }

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
        }

        public void UpdateFileInfo(int id, IFileUpdateModel fileUpdateModel)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
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

            if (fileUpdateModel.FileName != null)
            {
                file.FileName = fileUpdateModel.FileName;
            }

            if (fileUpdateModel.FileDownloadDirectory != null)
            {
                file.FileDownloadDirectory = fileUpdateModel.FileDownloadDirectory;
            }

            if (fileUpdateModel.FileDownloadMethod != null)
            {
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
                    throw new ArgumentOutOfRangeException(nameof(id));
                }

                file.UserId = fileUpdateModel.UserId.Value;
            }

            _fileRepository.Update(file);
        }

        public IFileReportsPageModel GetFiltered(IFileFilterModel filterModel)
        {
            if (filterModel == null)
            {
                throw new ArgumentNullException(nameof(filterModel));
            }

            if (filterModel.FileId != null)
            {
                if (filterModel.FileId.Value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(filterModel.FileId));
                }
            }

            return Map(_fileRepository.GetFiltered(Map(filterModel)));
        }

        #endregion

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
    }
}
