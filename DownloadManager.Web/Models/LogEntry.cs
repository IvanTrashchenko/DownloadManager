using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace DownloadManager.Web.Models
{
    public class LogEntry
    {
        public DateTime Datetime { get; set; }
        public string WorkNumber { get; set; }
        public string ThreadId { get; set; }
        public string Message { get; set; }

        public static LogEntry ParseLog(string log)
        {
            var parts = log.Split(new[] { ": " }, 2, StringSplitOptions.None);
            var datetime = DateTime.Parse(parts[0], CultureInfo.InvariantCulture);
            var rest = parts[1].Split(new[] { " - " }, 3, StringSplitOptions.None);

            var logEntry = new LogEntry
            {
                Datetime = datetime,
                WorkNumber = rest[0],
                ThreadId = rest[1],
                Message = rest[2]
            };

            return logEntry;
        }
    }
}