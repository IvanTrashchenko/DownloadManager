using System;
using DownloadManager.Core.Enums;

namespace DownloadManager.Data.Dal.Contract.Dto
{
    public class FileDto
    {
        public string FileName { get; set; }
        public string FileDownloadDirectory { get; set; }
        public DownloadMethod FileDownloadMethod { get; set; }
        public DateTime FileDownloadTime { get; set; }
        public int UserId { get; set; }
    }
}
