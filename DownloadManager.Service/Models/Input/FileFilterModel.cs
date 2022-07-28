using System;
using DownloadManager.Core.Enums;
using DownloadManager.Service.Contract.Models.Input;

namespace DownloadManager.Service.Models.Input
{
    public class FileFilterModel : IFileFilterModel
    {
        public int? FileId { get; set; }
        public string FileName { get; set; }
        public string FileDownloadDirectory { get; set; }
        public DownloadMethod? FileDownloadMethod { get; set; }
        public DateTimeOffset? FileDownloadTimeStart { get; set; }
        public DateTimeOffset? FileDownloadTimeEnd { get; set; }
        public string Username { get; set; }
    }
}
