using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DownloadManager.App.Enums;
using DownloadManager.App.Util;

namespace DownloadManager.App
{
    public partial class Main : Form
    {
        private static int workNumber = 0;

        public Main()
        {
            InitializeComponent();
            cmbDownloadMethod.DataSource = Enum.GetValues(typeof(DownloadMethod));
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!IsUrlValid() || !IsDestinationFolderValid()) return;

            //Enum.TryParse(cmbDownloadMethod.Text, out DownloadMethod method);

            //switch (method)
            //{
            //    case DownloadMethod.BeginInvoke:
            //        break;
            //    case DownloadMethod.Thread:
            //        break;
            //    case DownloadMethod.ThreadPool:
            //        break;
            //    case DownloadMethod.BackgroundWorker:
            //        break;
            //    case DownloadMethod.Task:
            //        break;
            //    default:
            //        throw new NotSupportedException();
            //}

            int currentWorkNumber = Interlocked.Increment(ref workNumber);

            string ext = Path.GetExtension(txtFileUrl.Text);
            var fileName = $"{IdCreator.CreateNewId()}{ext}";
            var path = Path.Combine(txtDestinationFolder.Text, fileName);

            txtResult.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}: Work {currentWorkNumber} - TId {Thread.CurrentThread.ManagedThreadId} - Downloading {fileName} has started." +
                                 Environment.NewLine);

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(txtFileUrl.Text, path);
                }
            }
            catch (Exception ex)
            {
                txtResult.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}: Work {currentWorkNumber} - TId {Thread.CurrentThread.ManagedThreadId} - Downloading {fileName} terminated. Exception: {ex.Message}" +
                                     Environment.NewLine);
            }

            txtResult.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}: Work {currentWorkNumber} - TId {Thread.CurrentThread.ManagedThreadId} - Downloading {fileName} was successful." +
                                 Environment.NewLine);
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
    }
}
