﻿using System;
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
    public partial class Register : Form
    {
        private IUserService _userService;

        public Register()
        {
            InitializeComponent();
            _userService = new UserService(new UserRepository());
        }

        public Register(Form loginForm) : this()
        {
            this.LoginForm = loginForm;
        }

        internal Form LoginForm
        {
            get;
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm.Show();
            this.txtUsername.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.txtConfirmPassword.Text = string.Empty;
            this.Hide();
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.LoginForm != null)
            {
                LoginForm.Close();
            }
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

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please confirm your password.");
                return false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return false;
            }

            return true;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!AreControlsValid()) return;

            try
            {
                _userService.RegisterUser(new UserCredentialsModel()
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text
                });

                int userId = _userService.GetUserIdByUsername(txtUsername.Text);

                var main = new Main(userId, txtUsername.Text, LoginForm);
                main.Show();
                this.txtUsername.Text = string.Empty;
                this.txtPassword.Text = string.Empty;
                this.txtConfirmPassword.Text = string.Empty;
                this.Hide();
            }
            catch (Exception ex)
            {
                if (ex.Message == $"User with name {txtUsername.Text} already exists.")
                {
                    MessageBox.Show(ex.Message);
                }
                else
                {
                    MessageBox.Show($"Error occured. Message: {ex.Message}. Stacktrace: {ex.StackTrace}");
                }
            }
        }
    }
}
