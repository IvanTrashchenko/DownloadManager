﻿
namespace DownloadManager.App
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtFileUrl = new System.Windows.Forms.TextBox();
            this.lblFileUrl = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDestinationFolder = new System.Windows.Forms.TextBox();
            this.btnFolderBrowserDialog = new System.Windows.Forms.Button();
            this.cmbDownloadMethod = new System.Windows.Forms.ComboBox();
            this.lblDownloadMethod = new System.Windows.Forms.Label();
            this.lblDestinationFolder = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtFileUrl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFileUrl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.cmbDownloadMethod, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblDownloadMethod, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblDestinationFolder, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblFileName, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtFileName, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(35, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(660, 228);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtFileUrl
            // 
            this.txtFileUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileUrl.Location = new System.Drawing.Point(0, 29);
            this.txtFileUrl.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.txtFileUrl.Name = "txtFileUrl";
            this.txtFileUrl.Size = new System.Drawing.Size(660, 23);
            this.txtFileUrl.TabIndex = 5;
            this.txtFileUrl.Text = "https://i.redd.it/ufxj58wy79w81.jpg";
            // 
            // lblFileUrl
            // 
            this.lblFileUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFileUrl.AutoSize = true;
            this.lblFileUrl.Location = new System.Drawing.Point(0, 9);
            this.lblFileUrl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblFileUrl.Name = "lblFileUrl";
            this.lblFileUrl.Size = new System.Drawing.Size(49, 15);
            this.lblFileUrl.TabIndex = 2;
            this.lblFileUrl.Text = "File URL";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Controls.Add(this.txtDestinationFolder, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnFolderBrowserDialog, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 140);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(660, 28);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // txtDestinationFolder
            // 
            this.txtDestinationFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestinationFolder.Location = new System.Drawing.Point(0, 1);
            this.txtDestinationFolder.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.txtDestinationFolder.Name = "txtDestinationFolder";
            this.txtDestinationFolder.Size = new System.Drawing.Size(594, 23);
            this.txtDestinationFolder.TabIndex = 10;
            this.txtDestinationFolder.Text = "C:\\DownloadManagerFolder";
            // 
            // btnFolderBrowserDialog
            // 
            this.btnFolderBrowserDialog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFolderBrowserDialog.AutoSize = true;
            this.btnFolderBrowserDialog.Location = new System.Drawing.Point(599, 0);
            this.btnFolderBrowserDialog.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnFolderBrowserDialog.Name = "btnFolderBrowserDialog";
            this.btnFolderBrowserDialog.Size = new System.Drawing.Size(61, 25);
            this.btnFolderBrowserDialog.TabIndex = 11;
            this.btnFolderBrowserDialog.Text = "...";
            this.btnFolderBrowserDialog.UseVisualStyleBackColor = true;
            this.btnFolderBrowserDialog.Click += new System.EventHandler(this.btnFolderBrowserDialog_Click);
            // 
            // cmbDownloadMethod
            // 
            this.cmbDownloadMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDownloadMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDownloadMethod.Location = new System.Drawing.Point(0, 197);
            this.cmbDownloadMethod.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.cmbDownloadMethod.Name = "cmbDownloadMethod";
            this.cmbDownloadMethod.Size = new System.Drawing.Size(660, 23);
            this.cmbDownloadMethod.TabIndex = 6;
            // 
            // lblDownloadMethod
            // 
            this.lblDownloadMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDownloadMethod.AutoSize = true;
            this.lblDownloadMethod.Location = new System.Drawing.Point(0, 177);
            this.lblDownloadMethod.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblDownloadMethod.Name = "lblDownloadMethod";
            this.lblDownloadMethod.Size = new System.Drawing.Size(106, 15);
            this.lblDownloadMethod.TabIndex = 4;
            this.lblDownloadMethod.Text = "Download method";
            // 
            // lblDestinationFolder
            // 
            this.lblDestinationFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDestinationFolder.AutoSize = true;
            this.lblDestinationFolder.Location = new System.Drawing.Point(0, 121);
            this.lblDestinationFolder.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblDestinationFolder.Name = "lblDestinationFolder";
            this.lblDestinationFolder.Size = new System.Drawing.Size(101, 15);
            this.lblDestinationFolder.TabIndex = 3;
            this.lblDestinationFolder.Text = "Destination folder";
            // 
            // lblFileName
            // 
            this.lblFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(0, 65);
            this.lblFileName.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(58, 15);
            this.lblFileName.TabIndex = 2;
            this.lblFileName.Text = "File name";
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(0, 85);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(660, 23);
            this.txtFileName.TabIndex = 5;
            this.txtFileName.Text = "file";
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(35, 233);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(660, 358);
            this.txtResult.TabIndex = 9;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.AutoSize = true;
            this.btnClear.Location = new System.Drawing.Point(623, 604);
            this.btnClear.Margin = new System.Windows.Forms.Padding(20, 50, 20, 50);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(72, 33);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.AutoSize = true;
            this.btnStart.Location = new System.Drawing.Point(528, 604);
            this.btnStart.Margin = new System.Windows.Forms.Padding(20, 50, 20, 50);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(89, 33);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Download";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 650);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(550, 550);
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(32);
            this.Text = "DownloadManager";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblFileUrl;
        private System.Windows.Forms.Label lblDestinationFolder;
        private System.Windows.Forms.Label lblDownloadMethod;
        private System.Windows.Forms.TextBox txtFileUrl;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.ComboBox cmbDownloadMethod;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtDestinationFolder;
        private System.Windows.Forms.Button btnFolderBrowserDialog;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtFileName;
    }
}
