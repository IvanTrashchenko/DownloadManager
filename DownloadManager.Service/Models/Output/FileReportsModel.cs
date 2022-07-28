using System;
using DownloadManager.Core.Enums;
using DownloadManager.Service.Contract.Models.Output;

namespace DownloadManager.Service.Models.Output
{
    public class FileReportsModel : IFileReportsModel
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FileDownloadDirectory { get; set; }
        public DownloadMethod FileDownloadMethod { get; set; }
        public DateTime FileDownloadTime { get; set; }
        public string Username { get; set; }
    }
}
