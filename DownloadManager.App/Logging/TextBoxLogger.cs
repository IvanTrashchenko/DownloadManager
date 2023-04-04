using DownloadManager.Service.Contract;
using System;
using System.Windows.Forms;

namespace DownloadManager.App.Logging
{
    internal class TextBoxLogger : ILogger
    {
        private readonly Main _mainForm;

        public TextBoxLogger(Main mainForm)
        {
            _mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));
        }

        public void Log(string message)
        {
            _mainForm.BeginInvoke((MethodInvoker)delegate
            {
                _mainForm.TxtResult.AppendText(message);
            });
        }
    }
}
