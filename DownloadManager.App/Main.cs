using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DownloadManager.App.Enums;

namespace DownloadManager.App
{
    public partial class Main : Form
    {
        private readonly HttpClient Client;

        private static string numberPattern = " ({0})";

        private static int workNumber = 0;

        public Main()
        {
            InitializeComponent();
            cmbDownloadMethod.DataSource = Enum.GetValues(typeof(DownloadMethod));
            Client = new HttpClient();
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

        private bool IsUrlValid()
        {
            if (string.IsNullOrWhiteSpace(txtFileUrl.Text))
            {
                MessageBox.Show("File URL cannot be empty.");
                return false;
            }

            if(!(Uri.TryCreate(txtFileUrl.Text, UriKind.Absolute, out Uri uriResult)
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

            if (!Path.IsPathFullyQualified(txtDestinationFolder.Text))
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

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (!IsUrlValid() || !IsNameValid() || !IsDestinationFolderValid()) return;

            Enum.TryParse(cmbDownloadMethod.Text, out DownloadMethod method);

            int currentWorkNumber = Interlocked.Increment(ref workNumber);

            txtResult.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}: Work {currentWorkNumber} - TId {Thread.CurrentThread.ManagedThreadId} - Downloading has started." +
                                 Environment.NewLine);

            try
            {
                switch (method)
                {
                    case DownloadMethod.BeginInvoke:
                        break;
                    case DownloadMethod.Thread:
                        break;
                    case DownloadMethod.ThreadPool:
                        break;
                    case DownloadMethod.BackgroundWorker:
                        break;
                    case DownloadMethod.Task:
                        var workTask = DownloadFileAsync(txtFileUrl.Text, txtFileName.Text, txtDestinationFolder.Text);
                        workTask.ContinueWith(x =>
                        {
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                txtResult.AppendText(
                                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}: Work {currentWorkNumber} - TId {Thread.CurrentThread.ManagedThreadId} - Downloading was successful." +
                                    Environment.NewLine);
                            });
                        });
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }
            catch (Exception ex)
            {
                txtResult.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}: Work {currentWorkNumber} - TId {Thread.CurrentThread.ManagedThreadId} - Downloading terminated. Exception: {ex.Message}" +
                                     Environment.NewLine);
            }
        }

        private async Task DownloadFileAsync(string url, string name, string folder)
        {
            var response = await Client.GetAsync(url);

            var ext = MimeTypes.MimeTypeMap.GetExtension(response.Content.Headers.ContentType.MediaType);

            var path = NextAvailableFilename(Path.Combine(folder, $"{name}{ext}"));

            using (var fileStream = File.Open(path, FileMode.CreateNew))
            {
                await response.Content.CopyToAsync(fileStream);
            }
        }

        private static string NextAvailableFilename(string path)
        {
            // Short-cut if already available
            if (!File.Exists(path))
                return path;

            // If path has extension then insert the number pattern just before the extension and return next filename
            if (Path.HasExtension(path))
                return GetNextFilename(path.Insert(path.LastIndexOf(Path.GetExtension(path)), numberPattern));

            // Otherwise just append the pattern to the path and return next filename
            return GetNextFilename(path + numberPattern);
        }

        private static string GetNextFilename(string pattern)
        {
            string tmp = string.Format(pattern, 1);
            if (tmp == pattern)
                throw new ArgumentException("The pattern must include an index place-holder");

            if (!File.Exists(tmp))
                return tmp; // short-circuit if no matches

            int min = 1, max = 2; // min is inclusive, max is exclusive/untested

            while (File.Exists(string.Format(pattern, max)))
            {
                min = max;
                max *= 2;
            }

            while (max != min + 1)
            {
                int pivot = (max + min) / 2;
                if (File.Exists(string.Format(pattern, pivot)))
                    min = pivot;
                else
                    max = pivot;
            }

            return string.Format(pattern, max);
        }
    }
}
