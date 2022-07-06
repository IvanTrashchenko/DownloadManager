using System.Collections.Generic;
using DownloadManager.Service.Contract.Models.Input;
using DownloadManager.Service.Contract.Models.Output;

namespace DownloadManager.Service.Contract
{
    public interface IFileService
    {
        IEnumerable<IFileViewModel> Get();
        IFileViewModel GetById(int id);
        void Add(IFileCreateModel fileCreateModel);
        void Update(int id, IFileUpdateModel fileUpdateModel);
        void Delete(int id);
    }
}
