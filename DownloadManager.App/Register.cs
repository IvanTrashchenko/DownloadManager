using System;
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
    public partial class Register : Form
    {
        private Form callingForm = null;

        public Register()
        {
            InitializeComponent();
        }
        public Register(Form callingForm) : this()
        {
            this.callingForm = callingForm;
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            callingForm.Show();
            this.txtUsername.Text = String.Empty;
            this.txtPassword.Text = String.Empty;
            this.txtConfirmPassword.Text = String.Empty;
            this.Hide();
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.callingForm != null)
            {
                callingForm.Close();
            }
        }
    }
}
