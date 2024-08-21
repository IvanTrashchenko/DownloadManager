using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace DownloadManager.Web.Logging
{
    public static class LogWriter
    {
        #region Fields

        private const string _defaultHomeFolder = @"C:\home";
        private static readonly string _targetLogFolder;
        private static readonly string _machineName;
        private static LogWriterSeverityFilter _filter = LogWriterSeverityFilter.Warning;
        private const string LoggingSeverityKey = "DownloadManager:LoggingSeverity";

        #endregion

        #region ctor

        static LogWriter()
        {
            // Set computer name.
            _machineName = Environment.MachineName;

            // Try to get home folder, if not present set as default.
            string homeFolder = Environment.GetEnvironmentVariable("HOME");
            homeFolder = string.IsNullOrEmpty(homeFolder) ? _defaultHomeFolder : homeFolder;

            // Set folder where log files will be written.
            _targetLogFolder = Path.Combine(homeFolder, "DownloadManagerLogs");

            // Crate log folder.
            if (!Directory.Exists(_targetLogFolder))
            {
                // When directory already exists, there is no error. No need to guard from racing condition on creation from other machine.
                Directory.CreateDirectory(_targetLogFolder);
            }

            string filterString = Environment.GetEnvironmentVariable(LoggingSeverityKey);

            if (!string.IsNullOrWhiteSpace(filterString))
            {
                bool success = Enum.TryParse(filterString, true, out LogWriterSeverityFilter filter);

                if (success)
                {
                    _filter = filter;

                    string message = $"Found valid LoggingSeverity '{_filter}'.";
                    Log(LogWriterSeverity.Info, message, "logWriter");
                }
                else
                {
                    string message = $"LoggingSeverity '{filterString}' is invalid. Allowed values are: 'None', 'Error', 'Warning', 'Info', 'Verbose'. Setting LoggingSeverity to 'Warning'.";
                    Log(LogWriterSeverity.Warning, message, "logWriter");
                }
            }
            else
            {
                string message = $"No LoggingSeverity configuration found. It should be configured in an Environment Variable '{LoggingSeverityKey}' or in the App Settings section " +
                                 $"of the Logic App Configuration with name '{LoggingSeverityKey}'. Setting LoggingSeverity to 'Warning'.";
                Log(LogWriterSeverity.Warning, message, "logWriter");
            }
        }

        #endregion

        #region Public methods

        public static void Log(LogWriterSeverity severity, string message, string methodName)
        {
            if (IsEventPassed(severity))
            {
                string fileName = $"log_{DateTime.UtcNow:yyyy-MM-dd}_{_machineName}.txt";
                string filePath = Path.Combine(_targetLogFolder, fileName);

                lock (_targetLogFolder)
                {
                    using (var fileStream = File.Open(filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
                    using (var writer = new StreamWriter(fileStream))
                    {
                        writer.WriteLine($"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss.fff}Z\t{severity}\t{methodName}\t{message}");
                    }
                }
            }
        }

        public static void Log(Exception ex, string methodName)
        {
            var severity = LogWriterSeverity.Error;

            if (IsEventPassed(severity))
            {
                string fileName = $"log_{DateTime.UtcNow:yyyy-MM-dd}_{_machineName}.txt";
                string filePath = Path.Combine(_targetLogFolder, fileName);

                lock (_targetLogFolder)
                {
                    using (var fileStream = File.Open(filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
                    using (var writer = new StreamWriter(fileStream))
                    {
                        writer.WriteLine($"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss.fff}Z\t{severity}\t{methodName}\t{ex.Message}\n{ex.StackTrace}");
                    }
                }
            }
        }

        #endregion

        #region Private methods

        private static bool IsEventPassed(LogWriterSeverity sv)
        {
            return ((int)sv & (int)_filter) != 0;
        }

        #endregion
    }

    [Flags]
    internal enum LogWriterSeverityFilter
    {
        None = 0x0000,
        Error = LogWriterSeverity.Error,
        Warning = LogWriterSeverity.Error | LogWriterSeverity.Warning,
        Info = LogWriterSeverity.Error | LogWriterSeverity.Warning | LogWriterSeverity.Info,
        Verbose = LogWriterSeverity.Error | LogWriterSeverity.Warning | LogWriterSeverity.Info | LogWriterSeverity.Verbose
    }

    [Flags]
    public enum LogWriterSeverity
    {
        Error = 0x0001,
        Warning = 0x0002,
        Info = 0x0004,
        Verbose = 0x0008
    }
}