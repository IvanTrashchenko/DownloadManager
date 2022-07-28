using System;
using DownloadManager.Core.Enums;

namespace DownloadManager.Service.Contract.Models.Output
{
    public interface IFileViewModel
    {
        int FileId { get; set; }
        string FileName { get; set; }
        string FileDownloadDirectory { get; set; }
        DownloadMethod FileDownloadMethod { get; set; }
        DateTime FileDownloadTime { get; set; }
        int UserId { get; set; }
    }
}
