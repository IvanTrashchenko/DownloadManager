﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloadManager.App
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            cmbDownloadMethod.DataSource = Enum.GetValues(typeof(DownloadMethod));
        }

    }
}
