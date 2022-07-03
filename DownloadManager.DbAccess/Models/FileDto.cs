using System;
using DownloadManager.DbAccess.Enums;

namespace DownloadManager.DbAccess.Models
{
    public class FileDto
    {
        public string FileName { get; set; }
        public string FileDownloadDirectory { get; set; }
        public DownloadMethod FileDownloadMethod { get; set; }
        public DateTime FileDownloadTime { get; set; }
    }
}
