using System;
using DownloadManager.Core.Enums;
using DownloadManager.Service.Contract.Models.Input;

namespace DownloadManager.Service.Models.Input
{
    public class FileUpdateModel : IFileUpdateModel
    {
        public string FileName { get; set; }
        public string FileDownloadDirectory { get; set; }
        public DownloadMethod? FileDownloadMethod { get; set; }
        public DateTime? FileDownloadTime { get; set; }
        public int? UserId { get; set; }
    }
}
