using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DownloadManager.Core.Enums;
using DownloadManager.Data.Dal.Repositories;
using DownloadManager.Service;
using DownloadManager.Service.Contract;
using DownloadManager.Service.Contract.Models.Output;
using DownloadManager.Service.Models.Input;

namespace DownloadManager.App
{
    public partial class Reports : Form
    {
        #region Private fields

        private IFileService _fileService;

        private int _currentAmountOfRows;

        #endregion

        #region ctor

        public Reports(IFileService fileService)
        {
            InitializeComponent();
            dateFileDownloadTimeStart.Value = DateTime.UtcNow;
            dateFileDownloadTimeEnd.Value = DateTime.UtcNow;
            cmbFileDownloadMethod.DataSource = Enum.GetValues(typeof(DownloadMethod));
            _fileService = fileService;
        }

        #endregion

        #region Event handlers

        private void Reports_Load(object sender, EventArgs e)
        {
            var result = _fileService.GetFiltered(new FileFilterModel());
            _currentAmountOfRows = result.Total;
            dataGridViewResults.DataSource = result.Items.ToList();
        }

        private void cbxFileId_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxFileId.Checked)
            {
                txtFileId.Enabled = true;
            }
            else
            {
                txtFileId.Enabled = false;
            }
        }

        private void cbxFileName_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxFileName.Checked)
            {
                txtFileName.Enabled = true;
            }
            else
            {
                txtFileName.Enabled = false;
            }
        }

        private void cbxFileDownloadDirectory_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxFileDownloadDirectory.Checked)
            {
                txtFileDownloadDirectory.Enabled = true;
            }
            else
            {
                txtFileDownloadDirectory.Enabled = false;
            }
        }

        private void cbxFileDownloadMethod_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxFileDownloadMethod.Checked)
            {
                cmbFileDownloadMethod.Enabled = true;
            }
            else
            {
                cmbFileDownloadMethod.Enabled = false;
            }
        }

        private void cbxUsername_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxUsername.Checked)
            {
                txtUsername.Enabled = true;
            }
            else
            {
                txtUsername.Enabled = false;
            }
        }

        private void cbxFileDownloadTimeStart_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxFileDownloadTimeStart.Checked)
            {
                dateFileDownloadTimeStart.Enabled = true;
            }
            else
            {
                dateFileDownloadTimeStart.Enabled = false;
            }
        }

        private void cbxFileDownloadTimeEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxFileDownloadTimeEnd.Checked)
            {
                dateFileDownloadTimeEnd.Enabled = true;
            }
            else
            {
                dateFileDownloadTimeEnd.Enabled = false;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            IFileReportsPageModel result;
            try
            {
                result = _fileService.GetFiltered(CreateFilterModel());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            _currentAmountOfRows = result.Total;
            dataGridViewResults.DataSource = result.Items.ToList();
        }

        private void txtFileId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void dataGridViewResults_DataSourceChanged(object sender, EventArgs e)
        {
            lblAmountOfRows.Text = $"Amount of rows: {_currentAmountOfRows}";
        }

        #endregion

        #region Private methods

        private FileFilterModel CreateFilterModel()
        {
            var model = new FileFilterModel();

            if (cbxFileId.Checked)
            {
                if (!string.IsNullOrWhiteSpace(txtFileId.Text))
                {
                    model.FileId = int.Parse(txtFileId.Text);
                }
            }

            if (cbxFileName.Checked)
            {
                model.FileName = txtFileName.Text;
            }

            if (cbxFileDownloadDirectory.Checked)
            {
                model.FileDownloadDirectory = txtFileDownloadDirectory.Text;
            }

            if (cbxFileDownloadMethod.Checked)
            {
                Enum.TryParse(cmbFileDownloadMethod.Text, out DownloadMethod method);
                model.FileDownloadMethod = method;
            }

            if (cbxUsername.Checked)
            {
                model.Username = txtUsername.Text;
            }

            if (cbxFileDownloadTimeStart.Checked)
            {
                model.FileDownloadTimeStart = dateFileDownloadTimeStart.Value;
            }

            if (cbxFileDownloadTimeEnd.Checked)
            {
                model.FileDownloadTimeEnd = dateFileDownloadTimeEnd.Value;
            }

            return model;
        }

        #endregion
    }
}
