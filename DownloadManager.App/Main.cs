﻿using System;
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
                    new TaskFactory().StartNew(() =>
                    {
                        DownloadFile(txtFileUrl.Text, txtFileName.Text, txtDestinationFolder.Text);
                    });
                    break;
                default:
                    throw new NotSupportedException();
            }

        }

        private void DownloadFile(string url, string name, string folder)
        {
            int currentWorkNumber = Interlocked.Increment(ref workNumber);

            var tId = Thread.CurrentThread.ManagedThreadId;

            string startMessage =
                $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}: Work {currentWorkNumber} - TId {tId} - Downloading has started." +
                Environment.NewLine;

            this.BeginInvoke((MethodInvoker)delegate
            {
                txtResult.AppendText(startMessage);
            });

            try
            {
                var response = Client.GetAsync(url).GetAwaiter().GetResult();

                var ext = MimeTypes.MimeTypeMap.GetExtension(response.Content.Headers.ContentType.MediaType);

                lock (this)
                {
                    string path = NextAvailableFilename(Path.Combine(folder, $"{name}{ext}"));

                    using (var fileStream = File.Open(path, FileMode.CreateNew, FileAccess.Write, FileShare.Read))
                    {
                        response.Content.CopyToAsync(fileStream).GetAwaiter().GetResult();
                    }
                }

                string endMessage = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}: Work {currentWorkNumber} - TId {tId} - Downloading was successful." +
                          Environment.NewLine;

                this.BeginInvoke((MethodInvoker)delegate
                {
                    txtResult.AppendText(endMessage);
                });
            }
            catch (Exception ex)
            {
                string exMessage =
                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}: Work {currentWorkNumber} - TId {tId} - Downloading terminated. Exception: {ex.Message}" +
                    Environment.NewLine;

                this.BeginInvoke((MethodInvoker)delegate
                {
                    txtResult.AppendText(exMessage);
                });
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