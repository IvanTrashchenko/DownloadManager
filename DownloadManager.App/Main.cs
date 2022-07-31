using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DownloadManager.Core.Enums;
using DownloadManager.Data.Dal.Repositories;
using DownloadManager.Service;
using DownloadManager.Service.Contract;
using DownloadManager.Service.Models.Input;
using File = System.IO.File;

namespace DownloadManager.App
{
    public partial class Main : Form
    {
        #region Fields

        private static int _workNumber = 0;

        private static IFileService _fileService;

        #endregion

        #region ctor

        public Main()
        {
            InitializeComponent();
            cmbDownloadMethod.DataSource = Enum.GetValues(typeof(DownloadMethod));
            _fileService = new FileService(new FileRepository());
        }

        #endregion

        #region Event Handlers

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (!IsUrlValid() || !IsNameValid() || !IsDestinationFolderValid()) return;

            Enum.TryParse(cmbDownloadMethod.Text, out DownloadMethod method);

            Parameter param = new Parameter
            {
                Url = txtFileUrl.Text,
                Name = txtFileName.Text,
                Folder = txtDestinationFolder.Text,
                Method = method
            };

            switch (method)
            {
                case DownloadMethod.BeginInvoke:
                    new Action<object>(DownloadFile).BeginInvoke(param, null, null);
                    break;
                case DownloadMethod.Thread:
                    new Thread(DownloadFile).Start(param);
                    break;
                case DownloadMethod.ThreadPool:
                    ThreadPool.QueueUserWorkItem(DownloadFile, param);
                    break;
                case DownloadMethod.BackgroundWorker:
                    BackgroundWorker worker = new BackgroundWorker();
                    worker.DoWork += worker_DoWork;
                    worker.RunWorkerAsync(param);
                    break;
                case DownloadMethod.Task:
                    Task.Factory.StartNew(DownloadFile, param);
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        private void btnFolderBrowserDialog_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtDestinationFolder.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e) => DownloadFile(e.Argument);

        #endregion

        #region File downloading methods

        private void DownloadFile(object state)
        {
            var param = (Parameter)state;
            DownloadFile(param.Url, param.Name, param.Folder, param.Method);
        }

        private void DownloadFile(string url, string name, string folder, DownloadMethod method)
        {
            int currentWorkNumber = Interlocked.Increment(ref _workNumber);

            var tId = Thread.CurrentThread.ManagedThreadId;

            string startMessage =
                $"{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff")}: Work {currentWorkNumber} - TId {tId} - Downloading has started." +
                Environment.NewLine;

            this.BeginInvoke((MethodInvoker)delegate
            {
                txtResult.AppendText(startMessage);
            });

            try
            {
                _fileService.DownloadFile(new FileDownloadModel()
                {
                    FileDownloadDirectory = folder,
                    FileDownloadMethod = method,
                    FileName = name,
                    Url = url
                });

                string endMessage = $"{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff")}: Work {currentWorkNumber} - TId {tId} - Downloading was successful." +
                                    Environment.NewLine;

                this.BeginInvoke((MethodInvoker)delegate
                {
                    txtResult.AppendText(endMessage);
                });
            }
            catch (Exception ex)
            {
                string exMessage =
                    $"{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff")}: Work {currentWorkNumber} - TId {tId} - Downloading terminated. Exception: {ex.Message}" +
                    Environment.NewLine;

                this.BeginInvoke((MethodInvoker)delegate
                {
                    txtResult.AppendText(exMessage);
                });
            }
        }

        #endregion

        #region Validation methods

        private bool IsUrlValid()
        {
            if (string.IsNullOrWhiteSpace(txtFileUrl.Text))
            {
                MessageBox.Show("File URL cannot be empty.");
                return false;
            }

            if (!(Uri.TryCreate(txtFileUrl.Text, UriKind.Absolute, out Uri uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)))
            {
                MessageBox.Show("File URL is not valid.");
                return false;
            }

            return true;
        }

        private bool IsNameValid()
        {
            if (string.IsNullOrWhiteSpace(txtFileName.Text))
            {
                MessageBox.Show("File name cannot be empty.");
                return false;
            }

            Regex containsABadCharacter = new Regex("["
                                                    + Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars())) + "]");

            if (containsABadCharacter.IsMatch(txtFileName.Text))
            {
                MessageBox.Show("File name contains invalid characters.");
                return false;
            }

            return true;
        }

        private bool IsDestinationFolderValid()
        {
            if (string.IsNullOrWhiteSpace(txtDestinationFolder.Text))
            {
                MessageBox.Show("Destination folder cannot be empty.");
                return false;
            }

            if (!IsPathValid(txtDestinationFolder.Text))
            {
                MessageBox.Show("Destination folder is not a valid path.");
                return false;
            }

            if (!Directory.Exists(txtDestinationFolder.Text))
            {
                Directory.CreateDirectory(txtDestinationFolder.Text);
            }

            return true;
        }

        private bool IsPathValid(string path, bool allowRelativePaths = false)
        {
            bool result = true;

            try
            {
                string fullPath = Path.GetFullPath(path);

                if (allowRelativePaths)
                {
                    result = Path.IsPathRooted(path);
                }
                else
                {
                    string root = Path.GetPathRoot(path);
                    result = string.IsNullOrEmpty(root.Trim(new char[] { '\\', '/' })) == false;
                }
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        #endregion

        #region Nested class

        private class Parameter
        {
            public string Url { get; set; }
            public string Name { get; set; }
            public string Folder { get; set; }
            public DownloadMethod Method { get; set; }
        }

        #endregion
    }
}
