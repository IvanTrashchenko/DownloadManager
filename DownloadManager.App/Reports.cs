﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DownloadManager.Core.Enums;
using DownloadManager.Data.Dal.Repositories;
using DownloadManager.Service;
using DownloadManager.Service.Contract;
using DownloadManager.Service.Models.Input;

namespace DownloadManager.App
{
    public partial class Reports : Form
    {
        #region Private fields

        private static IFileService _fileService;

        #endregion

        #region ctor
        public Reports(IFileService fileService)
        {
            InitializeComponent();
            cmbFileDownloadMethod.DataSource = Enum.GetValues(typeof(DownloadMethod));
            _fileService = fileService;
        }

        #endregion

        #region Event handlers

        private void Reports_Load(object sender, EventArgs e)
        {
            dataGridViewResults.DataSource = _fileService.GetFiltered(new FileFilterModel()).ToList();
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

        #endregion
    }
}
