using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DownloadManager.Data.Dal.Repositories;
using DownloadManager.Service.Contract;
using DownloadManager.Service.Models.Input;
using DownloadManager.Service.Services;

namespace DownloadManager.App
{
    public partial class Login : Form
    {
        private IUserService _userService;

        public Login()
        {
            InitializeComponent();
            _userService = new UserService(new UserRepository());
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registerForm = new Register(this);
            registerForm.Show();
            this.txtUsername.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.Hide();
        }

        private bool AreControlsValid()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username cannot be empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password cannot be empty.");
                return false;
            }

            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!AreControlsValid()) return;

            try
            {
                bool result = _userService.CheckCredentials(new UserCredentialsModel()
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text
                });

                if (result)
                {
                    int userId = _userService.GetUserIdByUsername(txtUsername.Text);

                    var main = new Main(userId, txtUsername.Text, this);
                    main.Show();
                    this.txtUsername.Text = string.Empty;
                    this.txtPassword.Text = string.Empty;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show($"User with these credentials was not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured. Message: {ex.Message}. Stacktrace: {ex.StackTrace}");
            }
        }
    }
}
