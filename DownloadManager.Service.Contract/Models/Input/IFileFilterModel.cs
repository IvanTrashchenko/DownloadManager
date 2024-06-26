﻿using System;
using DownloadManager.Core.Enums;

namespace DownloadManager.Service.Contract.Models.Input
{
    public interface IFileFilterModel
    {
        int? FileId { get; set; }
        string FileName { get; set; }
        string FileDownloadDirectory { get; set; }
        DownloadMethod? FileDownloadMethod { get; set; }
        DateTime? FileDownloadTimeStart { get; set; }
        DateTime? FileDownloadTimeEnd { get; set; }
        string Username { get; set; }
    }
}
