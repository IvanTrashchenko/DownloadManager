using DownloadManager.Core.Enums;

namespace DownloadManager.Web.Models
{
    public class DownloadModel
    {
        public string FileName { get; set; }
        public string FileDownloadDirectory { get; set; }
        public string Url { get; set; }
        public DownloadMethod FileDownloadMethod { get; set; }
    }
}