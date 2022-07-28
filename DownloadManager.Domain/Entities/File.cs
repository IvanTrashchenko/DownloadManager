using System;
using DownloadManager.Core.Enums;

namespace DownloadManager.Domain.Entities
{
    public class File
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FileDownloadDirectory { get; set; }
        public DownloadMethod FileDownloadMethod { get; set; }
        public DateTime FileDownloadTime { get; set; }
        public int UserId { get; set; }
    }
}
