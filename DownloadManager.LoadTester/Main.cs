using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DownloadManager.Core.Enums;
using DownloadManager.Data.Dal.Repositories;
using DownloadManager.Service;
using DownloadManager.Service.Contract;
using DownloadManager.Service.Models.Input;

namespace DownloadManager.LoadTester
{
    public partial class Main : Form
    {
        #region Fields

        private static Int32 workNumber = 0;

        private static Int32 finishedThreadsNumber = 0;

        private static bool isStopClicked = false;

        private static IFileService _fileService;

        #endregion

        #region ctor

        public Main()
        {
            InitializeComponent();
            _fileService = new FileService(new FileRepository());
        }

        #endregion

        #region Event handlers

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            txtIntervalBetweenExecutions.Enabled = false;
            txtNumOfExecutions.Enabled = false;
            txtNumOfThreads.Enabled = false;
            txtExecutionResultsDisplayFrequency.Enabled = false;

            workNumber = 0;
            finishedThreadsNumber = 0;

            if (rbtnThread.Checked)
            {
                Dictionary<Thread, Parameter> threadList = new Dictionary<Thread, Parameter>();
                for (int i = 0; i < Convert.ToInt32(this.txtNumOfThreads.Text); i++)
                {
                    Thread thread = new Thread(DoWork);

                    Parameter param = new Parameter
                    {
                        Name = "file",
                        Url = "https://i.redd.it/ufxj58wy79w81.jpg",
                        Folder = @"C:\DownloadManagerFolder",
                        Method = DownloadMethod.Thread,
                        UserId = 1,
                        Interval = Int32.Parse(this.txtIntervalBetweenExecutions.Text),
                        ExecutionsCount = Convert.ToInt32(this.txtNumOfExecutions.Text),
                        ThreadNumber = i + 1,
                        ExecutionResultsDisplayFrequency = Convert.ToInt32(this.txtExecutionResultsDisplayFrequency.Text)
                    };

                    threadList.Add(thread, param);
                }

                foreach (var threadWithParam in threadList)
                {
                    var thread = threadWithParam.Key;
                    var param = threadWithParam.Value;
                    thread.Start(param);
                }

                Thread waiterThread = new Thread(WaitForFinish);
                waiterThread.Start(threadList);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isStopClicked = true;
            btnStop.Enabled = false;
        }

        #endregion

        private void DoWork(Object parameter)
        {
            var param = (Parameter)parameter;

            bool success = false;

            for (int i = 0; i < param.ExecutionsCount; i++)
            {
                if (isStopClicked)
                {
                    break;
                }

                int currentWorkNumber = Interlocked.Increment(ref workNumber);

                try
                {
                    _fileService.DownloadFile(new FileDownloadModel()
                    {
                        FileName = param.Name,
                        FileDownloadDirectory = param.Folder,
                        FileDownloadMethod = param.Method,
                        Url = param.Url,
                        UserId = param.UserId
                    });

                    success = true;
                }
                catch (Exception ex)
                {
                    string exMessage =
                        $"{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff")}: Work {currentWorkNumber} - Thread {param.ThreadNumber} (TId {Thread.CurrentThread.ManagedThreadId}) - Execution {i + 1} terminated. Exception: {ex.Message}" +
                        Environment.NewLine;
                    txtResult.BeginInvoke((MethodInvoker)delegate
                    {
                        txtResult.AppendText(exMessage);
                    });
                }

                if (success && ((i % param.ExecutionResultsDisplayFrequency == 0) || i == param.ExecutionsCount - 1))
                {
                    string message =
                        $"{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff")}: Work {currentWorkNumber} - Thread {param.ThreadNumber} (TId {Thread.CurrentThread.ManagedThreadId}) - Execution {i + 1} finished." +
                        Environment.NewLine;
                    txtResult.BeginInvoke((MethodInvoker)delegate
                    {
                        txtResult.AppendText(message);
                    });
                }

                if (i != param.ExecutionsCount - 1)
                {
                    Thread.Sleep(param.Interval);
                }
            }

            Interlocked.Increment(ref finishedThreadsNumber);
        }

        private void WaitForFinish(Object parameter)
        {
            Dictionary<Thread, Parameter> threadList = (Dictionary<Thread, Parameter>)parameter;

            foreach (var thread in threadList.Keys)
            {
                thread.Join();
            }

            this.BeginInvoke((MethodInvoker)delegate
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                txtIntervalBetweenExecutions.Enabled = true;
                txtNumOfExecutions.Enabled = true;
                txtNumOfThreads.Enabled = true;
                txtExecutionResultsDisplayFrequency.Enabled = true;
            }
            );

            isStopClicked = false;
        }

        #region Nested class

        private class Parameter
        {
            public int Interval { get; set; }
            public int ExecutionsCount { get; set; }
            public int ThreadNumber { get; set; }
            public int ExecutionResultsDisplayFrequency { get; set; }
            public string Url { get; set; }
            public string Name { get; set; }
            public string Folder { get; set; }
            public DownloadMethod Method { get; set; }
            public int UserId { get; set; }
        }

        #endregion
    }
}
