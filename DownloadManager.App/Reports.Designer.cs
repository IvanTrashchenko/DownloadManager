
namespace DownloadManager.App
{
    partial class Reports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reports));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFileDownloadTimeStart = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblFileDownloadMethod = new System.Windows.Forms.Label();
            this.lblFileDownloadDirectory = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblFileId = new System.Windows.Forms.Label();
            this.txtFileId = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtFileDownloadDirectory = new System.Windows.Forms.TextBox();
            this.cmbFileDownloadMethod = new System.Windows.Forms.ComboBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblFileDownloadTimeEnd = new System.Windows.Forms.Label();
            this.dateFileDownloadTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dateFileDownloadTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.lblFileDownloadTimeStart, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblUsername, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblFileDownloadMethod, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFileDownloadDirectory, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFileName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFileId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFileId, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtFileName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtFileDownloadDirectory, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbFileDownloadMethod, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtUsername, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblFileDownloadTimeEnd, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.dateFileDownloadTimeStart, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.dateFileDownloadTimeEnd, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnFilter, 3, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(615, 152);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblFileDownloadTimeStart
            // 
            this.lblFileDownloadTimeStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFileDownloadTimeStart.AutoSize = true;
            this.lblFileDownloadTimeStart.Location = new System.Drawing.Point(156, 99);
            this.lblFileDownloadTimeStart.Name = "lblFileDownloadTimeStart";
            this.lblFileDownloadTimeStart.Size = new System.Drawing.Size(129, 15);
            this.lblFileDownloadTimeStart.TabIndex = 0;
            this.lblFileDownloadTimeStart.Text = "FileDownloadTimeStart";
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(3, 99);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(60, 15);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            // 
            // lblFileDownloadMethod
            // 
            this.lblFileDownloadMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFileDownloadMethod.AutoSize = true;
            this.lblFileDownloadMethod.Location = new System.Drawing.Point(462, 23);
            this.lblFileDownloadMethod.Name = "lblFileDownloadMethod";
            this.lblFileDownloadMethod.Size = new System.Drawing.Size(121, 15);
            this.lblFileDownloadMethod.TabIndex = 0;
            this.lblFileDownloadMethod.Text = "FileDownloadMethod";
            // 
            // lblFileDownloadDirectory
            // 
            this.lblFileDownloadDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFileDownloadDirectory.AutoSize = true;
            this.lblFileDownloadDirectory.Location = new System.Drawing.Point(309, 23);
            this.lblFileDownloadDirectory.Name = "lblFileDownloadDirectory";
            this.lblFileDownloadDirectory.Size = new System.Drawing.Size(127, 15);
            this.lblFileDownloadDirectory.TabIndex = 0;
            this.lblFileDownloadDirectory.Text = "FileDownloadDirectory";
            // 
            // lblFileName
            // 
            this.lblFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(156, 23);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(57, 15);
            this.lblFileName.TabIndex = 0;
            this.lblFileName.Text = "FileName";
            // 
            // lblFileId
            // 
            this.lblFileId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFileId.AutoSize = true;
            this.lblFileId.Location = new System.Drawing.Point(3, 23);
            this.lblFileId.Name = "lblFileId";
            this.lblFileId.Size = new System.Drawing.Size(35, 15);
            this.lblFileId.TabIndex = 0;
            this.lblFileId.Text = "FileId";
            // 
            // txtFileId
            // 
            this.txtFileId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFileId.Location = new System.Drawing.Point(3, 41);
            this.txtFileId.Name = "txtFileId";
            this.txtFileId.Size = new System.Drawing.Size(147, 23);
            this.txtFileId.TabIndex = 1;
            // 
            // txtFileName
            // 
            this.txtFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFileName.Location = new System.Drawing.Point(156, 41);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(147, 23);
            this.txtFileName.TabIndex = 3;
            // 
            // txtFileDownloadDirectory
            // 
            this.txtFileDownloadDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFileDownloadDirectory.Location = new System.Drawing.Point(309, 41);
            this.txtFileDownloadDirectory.Name = "txtFileDownloadDirectory";
            this.txtFileDownloadDirectory.Size = new System.Drawing.Size(147, 23);
            this.txtFileDownloadDirectory.TabIndex = 5;
            // 
            // cmbFileDownloadMethod
            // 
            this.cmbFileDownloadMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFileDownloadMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFileDownloadMethod.FormattingEnabled = true;
            this.cmbFileDownloadMethod.Items.AddRange(new object[] {
            "None",
            "BeginInvoke",
            "Thread",
            "ThreadPool",
            "BackgroundWorker",
            "Task"});
            this.cmbFileDownloadMethod.Location = new System.Drawing.Point(462, 41);
            this.cmbFileDownloadMethod.Name = "cmbFileDownloadMethod";
            this.cmbFileDownloadMethod.Size = new System.Drawing.Size(150, 23);
            this.cmbFileDownloadMethod.TabIndex = 6;
            // 
            // txtUsername
            // 
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsername.Location = new System.Drawing.Point(3, 117);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(147, 23);
            this.txtUsername.TabIndex = 7;
            // 
            // lblFileDownloadTimeEnd
            // 
            this.lblFileDownloadTimeEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFileDownloadTimeEnd.AutoSize = true;
            this.lblFileDownloadTimeEnd.Location = new System.Drawing.Point(309, 99);
            this.lblFileDownloadTimeEnd.Name = "lblFileDownloadTimeEnd";
            this.lblFileDownloadTimeEnd.Size = new System.Drawing.Size(125, 15);
            this.lblFileDownloadTimeEnd.TabIndex = 2;
            this.lblFileDownloadTimeEnd.Text = "FileDownloadTimeEnd";
            this.lblFileDownloadTimeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateFileDownloadTimeStart
            // 
            this.dateFileDownloadTimeStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateFileDownloadTimeStart.Location = new System.Drawing.Point(156, 117);
            this.dateFileDownloadTimeStart.Name = "dateFileDownloadTimeStart";
            this.dateFileDownloadTimeStart.Size = new System.Drawing.Size(147, 23);
            this.dateFileDownloadTimeStart.TabIndex = 8;
            // 
            // dateFileDownloadTimeEnd
            // 
            this.dateFileDownloadTimeEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateFileDownloadTimeEnd.Location = new System.Drawing.Point(309, 117);
            this.dateFileDownloadTimeEnd.Name = "dateFileDownloadTimeEnd";
            this.dateFileDownloadTimeEnd.Size = new System.Drawing.Size(147, 23);
            this.dateFileDownloadTimeEnd.TabIndex = 9;
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Location = new System.Drawing.Point(476, 93);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(17);
            this.btnFilter.Name = "btnFilter";
            this.tableLayoutPanel1.SetRowSpan(this.btnFilter, 2);
            this.btnFilter.Size = new System.Drawing.Size(122, 42);
            this.btnFilter.TabIndex = 10;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // dataGridViewResults
            // 
            this.dataGridViewResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResults.Location = new System.Drawing.Point(18, 173);
            this.dataGridViewResults.Name = "dataGridViewResults";
            this.dataGridViewResults.Size = new System.Drawing.Size(609, 339);
            this.dataGridViewResults.TabIndex = 1;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 530);
            this.Controls.Add(this.dataGridViewResults);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(661, 569);
            this.Name = "Reports";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblFileId;
        private System.Windows.Forms.TextBox txtFileId;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtFileDownloadDirectory;
        private System.Windows.Forms.Label lblFileDownloadDirectory;
        private System.Windows.Forms.ComboBox cmbFileDownloadMethod;
        private System.Windows.Forms.Label lblFileDownloadMethod;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblFileDownloadTimeStart;
        private System.Windows.Forms.Label lblFileDownloadTimeEnd;
        private System.Windows.Forms.DateTimePicker dateFileDownloadTimeStart;
        private System.Windows.Forms.DateTimePicker dateFileDownloadTimeEnd;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridView dataGridViewResults;
    }
}