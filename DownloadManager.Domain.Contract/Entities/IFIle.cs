using System;
using DownloadManager.Core.Enums;

namespace DownloadManager.Domain.Contract.Entities
{
    public interface IFile
    {
        int FileId { get; set; }
        string FileName { get; set; }
        string FileDownloadDirectory { get; set; }
        DownloadMethod FileDownloadMethod { get; set; }
        DateTime FileDownloadTime { get; set; }
    }
}
