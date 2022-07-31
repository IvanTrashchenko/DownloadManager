using System.Collections.Generic;
using DownloadManager.Service.Contract.Models.Output;

namespace DownloadManager.Service.Models.Output
{
    public class FileReportsPageModel : IFileReportsPageModel
    {
        public int Total { get; set; }
        public IEnumerable<IFileReportModel> Items { get; set; }
    }
}
