﻿using System;
using DownloadManager.Core.Enums;

namespace DownloadManager.Service.Contract.Models.Input
{
    public interface IFileCreateModel
    {
        string FileName { get; set; }
        string FileDownloadDirectory { get; set; }
        DownloadMethod FileDownloadMethod { get; set; }
        DateTime FileDownloadTime { get; set; }
    }
}
