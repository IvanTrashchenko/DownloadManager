using DownloadManager.Core.Enums;
using DownloadManager.Service.Contract.Models.Input;

namespace DownloadManager.Service.Models.Input
{
    public class FileDownloadModel : IFileDownloadModel
    {
        public string FileName { get; set; }
        public string FileDownloadDirectory { get; set; }
        public string Url { get; set; }
        public DownloadMethod FileDownloadMethod { get; set; }
    }
}
