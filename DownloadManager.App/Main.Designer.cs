
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
            this.cmbDownloadMethod = new System.Windows.Forms.ComboBox();
            this.txtFileUrl = new System.Windows.Forms.TextBox();
            this.lblDownloadMethod = new System.Windows.Forms.Label();
            this.lblDestinationFolder = new System.Windows.Forms.Label();
            this.lblFileUrl = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDestinationFolder = new System.Windows.Forms.TextBox();
            this.btnFolderBrowserDialog = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
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
            this.tableLayoutPanel1.Controls.Add(this.cmbDownloadMethod, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtFileUrl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDownloadMethod, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblDestinationFolder, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblFileUrl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(35, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(470, 197);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cmbDownloadMethod
            // 
            this.cmbDownloadMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDownloadMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDownloadMethod.Location = new System.Drawing.Point(0, 161);
            this.cmbDownloadMethod.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.cmbDownloadMethod.Name = "cmbDownloadMethod";
            this.cmbDownloadMethod.Size = new System.Drawing.Size(470, 23);
            this.cmbDownloadMethod.TabIndex = 6;
            // 
            // txtFileUrl
            // 
            this.txtFileUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileUrl.Location = new System.Drawing.Point(0, 33);
            this.txtFileUrl.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.txtFileUrl.Name = "txtFileUrl";
            this.txtFileUrl.Size = new System.Drawing.Size(470, 23);
            this.txtFileUrl.TabIndex = 5;
            this.txtFileUrl.Text = "https://i.redd.it/ufxj58wy79w81.jpg";
            // 
            // lblDownloadMethod
            // 
            this.lblDownloadMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDownloadMethod.AutoSize = true;
            this.lblDownloadMethod.Location = new System.Drawing.Point(0, 141);
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
            this.lblDestinationFolder.Location = new System.Drawing.Point(0, 77);
            this.lblDestinationFolder.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblDestinationFolder.Name = "lblDestinationFolder";
            this.lblDestinationFolder.Size = new System.Drawing.Size(101, 15);
            this.lblDestinationFolder.TabIndex = 3;
            this.lblDestinationFolder.Text = "Destination folder";
            // 
            // lblFileUrl
            // 
            this.lblFileUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFileUrl.AutoSize = true;
            this.lblFileUrl.Location = new System.Drawing.Point(0, 13);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 96);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(470, 32);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // txtDestinationFolder
            // 
            this.txtDestinationFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestinationFolder.Location = new System.Drawing.Point(0, 1);
            this.txtDestinationFolder.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.txtDestinationFolder.Name = "txtDestinationFolder";
            this.txtDestinationFolder.Size = new System.Drawing.Size(423, 23);
            this.txtDestinationFolder.TabIndex = 10;
            this.txtDestinationFolder.Text = "C:\\DownloadManagerFolder";
            // 
            // btnFolderBrowserDialog
            // 
            this.btnFolderBrowserDialog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFolderBrowserDialog.AutoSize = true;
            this.btnFolderBrowserDialog.Location = new System.Drawing.Point(428, 0);
            this.btnFolderBrowserDialog.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnFolderBrowserDialog.Name = "btnFolderBrowserDialog";
            this.btnFolderBrowserDialog.Size = new System.Drawing.Size(42, 25);
            this.btnFolderBrowserDialog.TabIndex = 11;
            this.btnFolderBrowserDialog.Text = "...";
            this.btnFolderBrowserDialog.UseVisualStyleBackColor = true;
            this.btnFolderBrowserDialog.Click += new System.EventHandler(this.btnFolderBrowserDialog_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(35, 203);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(470, 252);
            this.txtResult.TabIndex = 9;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 511);
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
    }
}

