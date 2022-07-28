using System.Collections.Generic;
using DownloadManager.Data.Dal.Contract.Dto;
using DownloadManager.Domain.Entities;

namespace DownloadManager.Data.Dal.Contract.Repositories
{
    public interface IFileRepository
    {
        IEnumerable<ReportDto> GetFiltered(FileFilterDto filterDto);
        IEnumerable<File> Get();
        File GetById(int id);
        void Add(FileDto fileDto);
        void Update(File file);
        void Delete(int id);
    }
}
