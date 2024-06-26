using DownloadManager.Service.Contract;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DownloadManager.Web.Models;

namespace DownloadManager.Web.Logging
{
    public class InMemoryLogger : ILogger
    {
        private static ConcurrentQueue<string> _logs = new ConcurrentQueue<string>();

        public void Log(string message)
        {
            _logs.Enqueue(message);
        }

        public IEnumerable<LogEntry> GetLogs()
        {
            return _logs.Select(LogEntry.ParseLog).OrderByDescending(l => l.Datetime);
        }

        public void Clear()
        {
            _logs = new ConcurrentQueue<string>();
        }
    }
}