using System;
using DownloadManager.Core.Enums;

namespace DownloadManager.Data.Dal.Contract.Dto
{
    public class FileFilterDto
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
