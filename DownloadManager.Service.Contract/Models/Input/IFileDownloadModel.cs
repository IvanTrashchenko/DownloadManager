using System;
using DownloadManager.Core.Enums;

namespace DownloadManager.Service.Contract.Models.Input
{
    public interface IFileDownloadModel
    {
        string FileName { get; set; }
        string FileDownloadDirectory { get; set; }
        string Url { get; set; }
        DownloadMethod FileDownloadMethod { get; set; }
        int UserId { get; set; }
    }
}
