using System.Collections.Generic;
using DownloadManager.Service.Contract.Models.Input;
using DownloadManager.Service.Contract.Models.Output;

namespace DownloadManager.Service.Contract
{
    public interface IFileService
    {
        IEnumerable<IFileReportsModel> GetFiltered(IFileFilterModel filterModel);
        IFileViewModel GetFileInfoById(int id);
        void DownloadFile(IFileDownloadModel fileDownloadModel);
        void UpdateFileInfo(int id, IFileUpdateModel fileUpdateModel);
    }
}
