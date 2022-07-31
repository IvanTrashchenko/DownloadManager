
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
            this.cbxFileName = new System.Windows.Forms.CheckBox();
            this.cbxFileDownloadTimeEnd = new System.Windows.Forms.CheckBox();
            this.cbxFileDownloadTimeStart = new System.Windows.Forms.CheckBox();
            this.cbxUsername = new System.Windows.Forms.CheckBox();
            this.cbxFileDownloadMethod = new System.Windows.Forms.CheckBox();
            this.cbxFileDownloadDirectory = new System.Windows.Forms.CheckBox();
            this.cbxFileId = new System.Windows.Forms.CheckBox();
            this.txtFileId = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtFileDownloadDirectory = new System.Windows.Forms.TextBox();
            this.cmbFileDownloadMethod = new System.Windows.Forms.ComboBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
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
            this.tableLayoutPanel1.Controls.Add(this.cbxFileName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxFileDownloadTimeEnd, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxFileDownloadTimeStart, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxUsername, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxFileDownloadMethod, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxFileDownloadDirectory, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxFileId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFileId, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtFileName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtFileDownloadDirectory, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbFileDownloadMethod, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtUsername, 0, 3);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(635, 152);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cbxFileName
            // 
            this.cbxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxFileName.AutoSize = true;
            this.cbxFileName.Location = new System.Drawing.Point(162, 19);
            this.cbxFileName.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cbxFileName.Name = "cbxFileName";
            this.cbxFileName.Size = new System.Drawing.Size(76, 19);
            this.cbxFileName.TabIndex = 0;
            this.cbxFileName.Text = "FileName";
            this.cbxFileName.UseVisualStyleBackColor = true;
            this.cbxFileName.CheckedChanged += new System.EventHandler(this.cbxFileName_CheckedChanged);
            // 
            // cbxFileDownloadTimeEnd
            // 
            this.cbxFileDownloadTimeEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxFileDownloadTimeEnd.AutoSize = true;
            this.cbxFileDownloadTimeEnd.Location = new System.Drawing.Point(320, 95);
            this.cbxFileDownloadTimeEnd.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cbxFileDownloadTimeEnd.Name = "cbxFileDownloadTimeEnd";
            this.cbxFileDownloadTimeEnd.Size = new System.Drawing.Size(144, 19);
            this.cbxFileDownloadTimeEnd.TabIndex = 0;
            this.cbxFileDownloadTimeEnd.Text = "FileDownloadTimeEnd";
            this.cbxFileDownloadTimeEnd.UseVisualStyleBackColor = true;
            this.cbxFileDownloadTimeEnd.CheckedChanged += new System.EventHandler(this.cbxFileDownloadTimeEnd_CheckedChanged);
            // 
            // cbxFileDownloadTimeStart
            // 
            this.cbxFileDownloadTimeStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxFileDownloadTimeStart.AutoSize = true;
            this.cbxFileDownloadTimeStart.Location = new System.Drawing.Point(162, 95);
            this.cbxFileDownloadTimeStart.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cbxFileDownloadTimeStart.Name = "cbxFileDownloadTimeStart";
            this.cbxFileDownloadTimeStart.Size = new System.Drawing.Size(148, 19);
            this.cbxFileDownloadTimeStart.TabIndex = 0;
            this.cbxFileDownloadTimeStart.Text = "FileDownloadTimeStart";
            this.cbxFileDownloadTimeStart.UseVisualStyleBackColor = true;
            this.cbxFileDownloadTimeStart.CheckedChanged += new System.EventHandler(this.cbxFileDownloadTimeStart_CheckedChanged);
            // 
            // cbxUsername
            // 
            this.cbxUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxUsername.AutoSize = true;
            this.cbxUsername.Location = new System.Drawing.Point(4, 95);
            this.cbxUsername.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cbxUsername.Name = "cbxUsername";
            this.cbxUsername.Size = new System.Drawing.Size(79, 19);
            this.cbxUsername.TabIndex = 0;
            this.cbxUsername.Text = "Username";
            this.cbxUsername.UseVisualStyleBackColor = true;
            this.cbxUsername.CheckedChanged += new System.EventHandler(this.cbxUsername_CheckedChanged);
            // 
            // cbxFileDownloadMethod
            // 
            this.cbxFileDownloadMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxFileDownloadMethod.AutoSize = true;
            this.cbxFileDownloadMethod.Location = new System.Drawing.Point(478, 19);
            this.cbxFileDownloadMethod.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cbxFileDownloadMethod.Name = "cbxFileDownloadMethod";
            this.cbxFileDownloadMethod.Size = new System.Drawing.Size(140, 19);
            this.cbxFileDownloadMethod.TabIndex = 0;
            this.cbxFileDownloadMethod.Text = "FileDownloadMethod";
            this.cbxFileDownloadMethod.UseVisualStyleBackColor = true;
            this.cbxFileDownloadMethod.CheckedChanged += new System.EventHandler(this.cbxFileDownloadMethod_CheckedChanged);
            // 
            // cbxFileDownloadDirectory
            // 
            this.cbxFileDownloadDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxFileDownloadDirectory.AutoSize = true;
            this.cbxFileDownloadDirectory.Location = new System.Drawing.Point(320, 19);
            this.cbxFileDownloadDirectory.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cbxFileDownloadDirectory.Name = "cbxFileDownloadDirectory";
            this.cbxFileDownloadDirectory.Size = new System.Drawing.Size(146, 19);
            this.cbxFileDownloadDirectory.TabIndex = 0;
            this.cbxFileDownloadDirectory.Text = "FileDownloadDirectory";
            this.cbxFileDownloadDirectory.UseVisualStyleBackColor = true;
            this.cbxFileDownloadDirectory.CheckedChanged += new System.EventHandler(this.cbxFileDownloadDirectory_CheckedChanged);
            // 
            // cbxFileId
            // 
            this.cbxFileId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxFileId.AutoSize = true;
            this.cbxFileId.Location = new System.Drawing.Point(4, 19);
            this.cbxFileId.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cbxFileId.Name = "cbxFileId";
            this.cbxFileId.Size = new System.Drawing.Size(54, 19);
            this.cbxFileId.TabIndex = 0;
            this.cbxFileId.Text = "FileId";
            this.cbxFileId.UseVisualStyleBackColor = true;
            this.cbxFileId.CheckedChanged += new System.EventHandler(this.cbxFileId_CheckedChanged);
            // 
            // txtFileId
            // 
            this.txtFileId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFileId.Enabled = false;
            this.txtFileId.Location = new System.Drawing.Point(3, 41);
            this.txtFileId.Name = "txtFileId";
            this.txtFileId.Size = new System.Drawing.Size(152, 23);
            this.txtFileId.TabIndex = 1;
            this.txtFileId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFileId_KeyPress);
            // 
            // txtFileName
            // 
            this.txtFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFileName.Enabled = false;
            this.txtFileName.Location = new System.Drawing.Point(161, 41);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(152, 23);
            this.txtFileName.TabIndex = 3;
            // 
            // txtFileDownloadDirectory
            // 
            this.txtFileDownloadDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFileDownloadDirectory.Enabled = false;
            this.txtFileDownloadDirectory.Location = new System.Drawing.Point(319, 41);
            this.txtFileDownloadDirectory.Name = "txtFileDownloadDirectory";
            this.txtFileDownloadDirectory.Size = new System.Drawing.Size(152, 23);
            this.txtFileDownloadDirectory.TabIndex = 5;
            // 
            // cmbFileDownloadMethod
            // 
            this.cmbFileDownloadMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFileDownloadMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFileDownloadMethod.Enabled = false;
            this.cmbFileDownloadMethod.FormattingEnabled = true;
            this.cmbFileDownloadMethod.Location = new System.Drawing.Point(477, 41);
            this.cmbFileDownloadMethod.Name = "cmbFileDownloadMethod";
            this.cmbFileDownloadMethod.Size = new System.Drawing.Size(155, 23);
            this.cmbFileDownloadMethod.TabIndex = 6;
            // 
            // txtUsername
            // 
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsername.Enabled = false;
            this.txtUsername.Location = new System.Drawing.Point(3, 117);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(152, 23);
            this.txtUsername.TabIndex = 7;
            // 
            // dateFileDownloadTimeStart
            // 
            this.dateFileDownloadTimeStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateFileDownloadTimeStart.Enabled = false;
            this.dateFileDownloadTimeStart.Location = new System.Drawing.Point(161, 117);
            this.dateFileDownloadTimeStart.Name = "dateFileDownloadTimeStart";
            this.dateFileDownloadTimeStart.Size = new System.Drawing.Size(152, 23);
            this.dateFileDownloadTimeStart.TabIndex = 8;
            // 
            // dateFileDownloadTimeEnd
            // 
            this.dateFileDownloadTimeEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateFileDownloadTimeEnd.Enabled = false;
            this.dateFileDownloadTimeEnd.Location = new System.Drawing.Point(319, 117);
            this.dateFileDownloadTimeEnd.Name = "dateFileDownloadTimeEnd";
            this.dateFileDownloadTimeEnd.Size = new System.Drawing.Size(152, 23);
            this.dateFileDownloadTimeEnd.TabIndex = 9;
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Location = new System.Drawing.Point(491, 93);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(17);
            this.btnFilter.Name = "btnFilter";
            this.tableLayoutPanel1.SetRowSpan(this.btnFilter, 2);
            this.btnFilter.Size = new System.Drawing.Size(127, 42);
            this.btnFilter.TabIndex = 10;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dataGridViewResults
            // 
            this.dataGridViewResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResults.Location = new System.Drawing.Point(18, 173);
            this.dataGridViewResults.Name = "dataGridViewResults";
            this.dataGridViewResults.ReadOnly = true;
            this.dataGridViewResults.Size = new System.Drawing.Size(629, 339);
            this.dataGridViewResults.TabIndex = 1;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 530);
            this.Controls.Add(this.dataGridViewResults);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(681, 569);
            this.Name = "Reports";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.Reports_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtFileId;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtFileDownloadDirectory;
        private System.Windows.Forms.ComboBox cmbFileDownloadMethod;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.DateTimePicker dateFileDownloadTimeStart;
        private System.Windows.Forms.DateTimePicker dateFileDownloadTimeEnd;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridView dataGridViewResults;
        private System.Windows.Forms.CheckBox cbxFileId;
        private System.Windows.Forms.CheckBox cbxFileDownloadTimeEnd;
        private System.Windows.Forms.CheckBox cbxFileDownloadTimeStart;
        private System.Windows.Forms.CheckBox cbxUsername;
        private System.Windows.Forms.CheckBox cbxFileDownloadMethod;
        private System.Windows.Forms.CheckBox cbxFileDownloadDirectory;
        private System.Windows.Forms.CheckBox cbxFileName;
    }
}