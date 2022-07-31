using System.Collections.Generic;

namespace DownloadManager.Service.Contract.Models.Output
{
    public interface IFileReportsPageModel
    {
        int Total { get; set; }
        IEnumerable<IFileReportModel> Items { get; set; }
    }
}
