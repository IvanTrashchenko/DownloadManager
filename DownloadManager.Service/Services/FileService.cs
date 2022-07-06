using System;
using System.Collections.Generic;
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

            _fileRepository.Update(file);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
                FileDownloadTime = file.FileDownloadTime
            };

        private FileDto Map(IFileCreateModel fileCreateModel) =>
            new FileDto()
            {
                FileName = fileCreateModel.FileName,
                FileDownloadDirectory = fileCreateModel.FileDownloadDirectory,
                FileDownloadMethod = fileCreateModel.FileDownloadMethod,
                FileDownloadTime = fileCreateModel.FileDownloadTime
            };

        #endregion
    }
}
