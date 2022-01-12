﻿using Inventory_Management_System_A_.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using User_Registration_A_;

namespace Inventory_Management_System_A_.Presentation_Layer
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if(usernameTextBox.Text=="")
            {
                MessageBox.Show("Username cannot be empty");

            }
            else if(passwordTextBox.Text=="")
            {
                MessageBox.Show("Password cannot be empty");
            }
            else
            {
                UserDataAccess userDataAccess = new UserDataAccess();
                if(userDataAccess.LoginValidation(usernameTextBox.Text,passwordTextBox.Text))
                {
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }
        }

        private void userRegistrationLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserRegistration userRegistration = new UserRegistration();
            userRegistration.Show();
            this.Hide();
        }
    }
}
