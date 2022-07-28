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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registerForm = new Register(this);
            registerForm.Show();
            this.txtUsername.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.Hide();
        }
    }
}
