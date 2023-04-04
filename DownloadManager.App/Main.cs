using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DownloadManager.App.Logging;
using DownloadManager.Core.Enums;
using DownloadManager.Data.Dal.Repositories;
using DownloadManager.Service;
using DownloadManager.Service.Contract;
using DownloadManager.Service.Models.Input;

namespace DownloadManager.App
{
    public partial class Main : Form
    {
        #region Fields

        private static IFileService _fileService;

        private readonly int _userId;
        
        #endregion

        #region ctors

        public Main()
        {
            InitializeComponent();
            cmbDownloadMethod.DataSource = Enum.GetValues(typeof(DownloadMethod));
            _fileService = new FileService(new FileRepository(), new TextBoxLogger(this));
        }

        public Main(int userId, string username, Form loginForm) : this()
        {
            _userId = userId;
            lblAuth.Text = $"Hello, {username}.";
            this.LoginForm = loginForm;
        }

        #endregion

        #region Properties

        internal Form LoginForm
        {
            get;
        }

        internal TextBox TxtResult => txtResult;

        #endregion

        #region Event Handlers

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (!IsUrlValid() || !IsNameValid() || !IsDestinationFolderValid()) return;

            Enum.TryParse(cmbDownloadMethod.Text, out DownloadMethod method);

            _fileService.DownloadFile(new FileDownloadModel()
            {
                FileName = txtFileName.Text,
                FileDownloadDirectory = txtDestinationFolder.Text,
                FileDownloadMethod = method,
                Url = txtFileUrl.Text,
                UserId = _userId
            });
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

        private void linkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm.Show();
            this.txtDestinationFolder.Text = string.Empty;
            this.txtFileName.Text = string.Empty;
            this.txtFileUrl.Text = string.Empty;
            this.txtResult.Clear();
            this.Hide();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.LoginForm != null)
            {
                LoginForm.Close();
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var reportsForm = new Reports(_fileService);
            reportsForm.Show();
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
    }
}
