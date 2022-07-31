using System.Collections.Generic;

namespace DownloadManager.Data.Dal.Contract.Dto
{
    public class ReportsPageDto
    {
        public int Total { get; set; }
        public IEnumerable<ReportDto> Items { get; set; }
    }
}
