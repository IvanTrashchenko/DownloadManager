using System;
using System.Collections.Generic;
using System.Linq;
using DownloadManager.Data.Dal.Contract.Dto;
using DownloadManager.Data.Dal.Contract.Repositories;
using DownloadManager.Domain.Entities;
using DownloadManager.Service.Contract;
using DownloadManager.Service.Contract.Models.Input;
using DownloadManager.Service.Contract.Models.Output;
using DownloadManager.Service.Models.Output;

namespace DownloadManager.Service
{
    public class FileService : IFileService
    {
        #region Private fields

        private readonly IFileRepository _fileRepository;

        #endregion

        #region ctor

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository ?? throw new ArgumentNullException(nameof(fileRepository));
        }

        #endregion

        #region Public methods

        public IEnumerable<IFileViewModel> Get()
        {
            throw new NotImplementedException();
        }

        public IFileViewModel GetById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return Map(_fileRepository.GetById(id));
        }

        public void Add(IFileCreateModel fileCreateModel)
        {
            if (fileCreateModel == null)
            {
                throw new ArgumentNullException(nameof(fileCreateModel));
            }

            if (fileCreateModel.FileName == null)
            {
                throw new ArgumentNullException(nameof(fileCreateModel.FileName));
            }

            if (fileCreateModel.FileDownloadDirectory == null)
            {
                throw new ArgumentNullException(nameof(fileCreateModel.FileDownloadDirectory));
            }

            if (fileCreateModel.UserId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(fileCreateModel.UserId));
            }

            _fileRepository.Add(Map(fileCreateModel));
        }

        public void Update(int id, IFileUpdateModel fileUpdateModel)
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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IFileReportsModel> GetFiltered(IFileFilterModel filterModel)
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

            return _fileRepository.GetFiltered(Map(filterModel)).Select(Map);
        }

        #endregion

        #region Mapping methods

        private IFileViewModel Map(File file) =>
            new FileViewModel()
            {
                FileId = file.FileId,
                FileName = file.FileName,
                FileDownloadDirectory = file.FileDownloadDirectory,
                FileDownloadMethod = file.FileDownloadMethod,
                FileDownloadTime = file.FileDownloadTime,
                UserId = file.UserId
            };

        private FileDto Map(IFileCreateModel fileCreateModel) =>
            new FileDto()
            {
                FileName = fileCreateModel.FileName,
                FileDownloadDirectory = fileCreateModel.FileDownloadDirectory,
                FileDownloadMethod = fileCreateModel.FileDownloadMethod,
                FileDownloadTime = fileCreateModel.FileDownloadTime,
                UserId = fileCreateModel.UserId
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

        private IFileReportsModel Map(ReportDto dto) =>
            new FileReportsModel()
            {
                FileId = dto.FileId,
                FileDownloadDirectory = dto.FileDownloadDirectory,
                FileDownloadMethod = dto.FileDownloadMethod,
                FileDownloadTime = dto.FileDownloadTime,
                FileName = dto.FileName,
                Username = dto.Username
            };

        #endregion
    }
}
