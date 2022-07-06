
namespace DownloadManager.LoadTester
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtExecutionResultsDisplayFrequency = new System.Windows.Forms.TextBox();
            this.txtIntervalBetweenExecutions = new System.Windows.Forms.TextBox();
            this.txtNumOfExecutions = new System.Windows.Forms.TextBox();
            this.lblIntervalBetweenExecutions = new System.Windows.Forms.Label();
            this.lblNumOfExecutions = new System.Windows.Forms.Label();
            this.lblNumOfTasks = new System.Windows.Forms.Label();
            this.txtNumOfThreads = new System.Windows.Forms.TextBox();
            this.lblExecutionResultsDisplayFrequency = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gbDownloadMethod = new System.Windows.Forms.GroupBox();
            this.rbtnThread = new System.Windows.Forms.RadioButton();
            this.rbtnBeginInvoke = new System.Windows.Forms.RadioButton();
            this.rbtnThreadPool = new System.Windows.Forms.RadioButton();
            this.rbtnBackgroundWorker = new System.Windows.Forms.RadioButton();
            this.rbtnTask = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbDownloadMethod.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtExecutionResultsDisplayFrequency, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtIntervalBetweenExecutions, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtNumOfExecutions, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblIntervalBetweenExecutions, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblNumOfExecutions, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNumOfTasks, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNumOfThreads, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblExecutionResultsDisplayFrequency, 0, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(570, 216);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtExecutionResultsDisplayFrequency
            // 
            this.txtExecutionResultsDisplayFrequency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExecutionResultsDisplayFrequency.Location = new System.Drawing.Point(0, 189);
            this.txtExecutionResultsDisplayFrequency.Margin = new System.Windows.Forms.Padding(0);
            this.txtExecutionResultsDisplayFrequency.Name = "txtExecutionResultsDisplayFrequency";
            this.txtExecutionResultsDisplayFrequency.Size = new System.Drawing.Size(570, 23);
            this.txtExecutionResultsDisplayFrequency.TabIndex = 7;
            this.txtExecutionResultsDisplayFrequency.Text = "1";
            // 
            // txtIntervalBetweenExecutions
            // 
            this.txtIntervalBetweenExecutions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIntervalBetweenExecutions.Location = new System.Drawing.Point(0, 135);
            this.txtIntervalBetweenExecutions.Margin = new System.Windows.Forms.Padding(0);
            this.txtIntervalBetweenExecutions.Name = "txtIntervalBetweenExecutions";
            this.txtIntervalBetweenExecutions.Size = new System.Drawing.Size(570, 23);
            this.txtIntervalBetweenExecutions.TabIndex = 5;
            this.txtIntervalBetweenExecutions.Text = "1000";
            // 
            // txtNumOfExecutions
            // 
            this.txtNumOfExecutions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumOfExecutions.Location = new System.Drawing.Point(0, 81);
            this.txtNumOfExecutions.Margin = new System.Windows.Forms.Padding(0);
            this.txtNumOfExecutions.Name = "txtNumOfExecutions";
            this.txtNumOfExecutions.Size = new System.Drawing.Size(570, 23);
            this.txtNumOfExecutions.TabIndex = 4;
            this.txtNumOfExecutions.Text = "1";
            // 
            // lblIntervalBetweenExecutions
            // 
            this.lblIntervalBetweenExecutions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIntervalBetweenExecutions.AutoSize = true;
            this.lblIntervalBetweenExecutions.Location = new System.Drawing.Point(0, 120);
            this.lblIntervalBetweenExecutions.Margin = new System.Windows.Forms.Padding(0);
            this.lblIntervalBetweenExecutions.Name = "lblIntervalBetweenExecutions";
            this.lblIntervalBetweenExecutions.Size = new System.Drawing.Size(231, 15);
            this.lblIntervalBetweenExecutions.TabIndex = 2;
            this.lblIntervalBetweenExecutions.Text = "Interval between executions (milliseconds)";
            // 
            // lblNumOfExecutions
            // 
            this.lblNumOfExecutions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNumOfExecutions.AutoSize = true;
            this.lblNumOfExecutions.Location = new System.Drawing.Point(0, 66);
            this.lblNumOfExecutions.Margin = new System.Windows.Forms.Padding(0);
            this.lblNumOfExecutions.Name = "lblNumOfExecutions";
            this.lblNumOfExecutions.Size = new System.Drawing.Size(125, 15);
            this.lblNumOfExecutions.TabIndex = 1;
            this.lblNumOfExecutions.Text = "Number of executions";
            // 
            // lblNumOfTasks
            // 
            this.lblNumOfTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNumOfTasks.AutoSize = true;
            this.lblNumOfTasks.Location = new System.Drawing.Point(0, 12);
            this.lblNumOfTasks.Margin = new System.Windows.Forms.Padding(0);
            this.lblNumOfTasks.Name = "lblNumOfTasks";
            this.lblNumOfTasks.Size = new System.Drawing.Size(94, 15);
            this.lblNumOfTasks.TabIndex = 0;
            this.lblNumOfTasks.Text = "Number of tasks";
            // 
            // txtNumOfThreads
            // 
            this.txtNumOfThreads.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumOfThreads.Location = new System.Drawing.Point(0, 27);
            this.txtNumOfThreads.Margin = new System.Windows.Forms.Padding(0);
            this.txtNumOfThreads.Name = "txtNumOfThreads";
            this.txtNumOfThreads.Size = new System.Drawing.Size(570, 23);
            this.txtNumOfThreads.TabIndex = 3;
            this.txtNumOfThreads.Text = "1";
            // 
            // lblExecutionResultsDisplayFrequency
            // 
            this.lblExecutionResultsDisplayFrequency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblExecutionResultsDisplayFrequency.AutoSize = true;
            this.lblExecutionResultsDisplayFrequency.Location = new System.Drawing.Point(0, 174);
            this.lblExecutionResultsDisplayFrequency.Margin = new System.Windows.Forms.Padding(0);
            this.lblExecutionResultsDisplayFrequency.Name = "lblExecutionResultsDisplayFrequency";
            this.lblExecutionResultsDisplayFrequency.Size = new System.Drawing.Size(192, 15);
            this.lblExecutionResultsDisplayFrequency.TabIndex = 6;
            this.lblExecutionResultsDisplayFrequency.Text = "Execution results display frequency";
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(35, 238);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(850, 447);
            this.txtResult.TabIndex = 1;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.AutoSize = true;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(813, 695);
            this.btnStop.Margin = new System.Windows.Forms.Padding(20, 50, 20, 50);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(72, 33);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.AutoSize = true;
            this.btnClear.Location = new System.Drawing.Point(731, 695);
            this.btnClear.Margin = new System.Windows.Forms.Padding(20, 50, 20, 50);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(72, 33);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.AutoSize = true;
            this.btnStart.Location = new System.Drawing.Point(647, 695);
            this.btnStart.Margin = new System.Windows.Forms.Padding(20, 50, 20, 50);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(72, 33);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.gbDownloadMethod, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(35, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(850, 230);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // gbDownloadMethod
            // 
            this.gbDownloadMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDownloadMethod.Controls.Add(this.rbtnTask);
            this.gbDownloadMethod.Controls.Add(this.rbtnBackgroundWorker);
            this.gbDownloadMethod.Controls.Add(this.rbtnThreadPool);
            this.gbDownloadMethod.Controls.Add(this.rbtnThread);
            this.gbDownloadMethod.Controls.Add(this.rbtnBeginInvoke);
            this.gbDownloadMethod.Location = new System.Drawing.Point(590, 10);
            this.gbDownloadMethod.Margin = new System.Windows.Forms.Padding(20, 10, 0, 10);
            this.gbDownloadMethod.Name = "gbDownloadMethod";
            this.gbDownloadMethod.Size = new System.Drawing.Size(260, 202);
            this.gbDownloadMethod.TabIndex = 1;
            this.gbDownloadMethod.TabStop = false;
            this.gbDownloadMethod.Text = "Download method";
            // 
            // rbtnThread
            // 
            this.rbtnThread.AutoSize = true;
            this.rbtnThread.Checked = true;
            this.rbtnThread.Location = new System.Drawing.Point(24, 52);
            this.rbtnThread.Name = "rbtnThread";
            this.rbtnThread.Size = new System.Drawing.Size(61, 19);
            this.rbtnThread.TabIndex = 1;
            this.rbtnThread.TabStop = true;
            this.rbtnThread.Text = "Thread";
            this.rbtnThread.UseVisualStyleBackColor = true;
            // 
            // rbtnBeginInvoke
            // 
            this.rbtnBeginInvoke.AutoSize = true;
            this.rbtnBeginInvoke.Enabled = false;
            this.rbtnBeginInvoke.Location = new System.Drawing.Point(24, 27);
            this.rbtnBeginInvoke.Name = "rbtnBeginInvoke";
            this.rbtnBeginInvoke.Size = new System.Drawing.Size(139, 19);
            this.rbtnBeginInvoke.TabIndex = 0;
            this.rbtnBeginInvoke.Text = "Delegate.BeginInvoke";
            this.rbtnBeginInvoke.UseVisualStyleBackColor = true;
            // 
            // rbtnThreadPool
            // 
            this.rbtnThreadPool.AutoSize = true;
            this.rbtnThreadPool.Enabled = false;
            this.rbtnThreadPool.Location = new System.Drawing.Point(24, 77);
            this.rbtnThreadPool.Name = "rbtnThreadPool";
            this.rbtnThreadPool.Size = new System.Drawing.Size(85, 19);
            this.rbtnThreadPool.TabIndex = 2;
            this.rbtnThreadPool.Text = "ThreadPool";
            this.rbtnThreadPool.UseVisualStyleBackColor = true;
            // 
            // rbtnBackgroundWorker
            // 
            this.rbtnBackgroundWorker.AutoSize = true;
            this.rbtnBackgroundWorker.Enabled = false;
            this.rbtnBackgroundWorker.Location = new System.Drawing.Point(24, 102);
            this.rbtnBackgroundWorker.Name = "rbtnBackgroundWorker";
            this.rbtnBackgroundWorker.Size = new System.Drawing.Size(127, 19);
            this.rbtnBackgroundWorker.TabIndex = 3;
            this.rbtnBackgroundWorker.Text = "BackgroundWorker";
            this.rbtnBackgroundWorker.UseVisualStyleBackColor = true;
            // 
            // rbtnTask
            // 
            this.rbtnTask.AutoSize = true;
            this.rbtnTask.Enabled = false;
            this.rbtnTask.Location = new System.Drawing.Point(24, 127);
            this.rbtnTask.Name = "rbtnTask";
            this.rbtnTask.Size = new System.Drawing.Size(47, 19);
            this.rbtnTask.TabIndex = 4;
            this.rbtnTask.Text = "Task";
            this.rbtnTask.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 741);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.txtResult);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(650, 650);
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(32);
            this.Text = "DownloadManager.LoadTester";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.gbDownloadMethod.ResumeLayout(false);
            this.gbDownloadMethod.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblIntervalBetweenExecutions;
        private System.Windows.Forms.Label lblNumOfExecutions;
        private System.Windows.Forms.Label lblNumOfTasks;
        private System.Windows.Forms.TextBox txtNumOfThreads;
        private System.Windows.Forms.TextBox txtIntervalBetweenExecutions;
        private System.Windows.Forms.TextBox txtNumOfExecutions;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblExecutionResultsDisplayFrequency;
        private System.Windows.Forms.TextBox txtExecutionResultsDisplayFrequency;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox gbDownloadMethod;
        private System.Windows.Forms.RadioButton rbtnThread;
        private System.Windows.Forms.RadioButton rbtnBeginInvoke;
        private System.Windows.Forms.RadioButton rbtnThreadPool;
        private System.Windows.Forms.RadioButton rbtnBackgroundWorker;
        private System.Windows.Forms.RadioButton rbtnTask;
    }
}

