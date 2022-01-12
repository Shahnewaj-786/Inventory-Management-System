﻿using Inventory_Management_System_A_.Data_Access_Layer;
using Inventory_Management_System_A_.Presentation_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Registration_A_
{
    public partial class UserRegistration : Form
    {
        public UserRegistration()
        {
            InitializeComponent();
            submitButton.Enabled = false;
        }

        private void UserRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void termsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(termsCheckBox.Checked)
            {
                submitButton.Enabled = true;
            }
            else
            {
                submitButton.Enabled = false;
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if(nameTextBox.Text=="")
            {
                MessageBox.Show("Name cannot be empty");
            }
            else if(usernameTextBox.Text=="")
            {
                MessageBox.Show("Username cannot be empty");
            }
            else if (emailTextBox.Text == "")
            {
                MessageBox.Show("Email cannot be empty");
            }
            else if (passwordTextBox.Text == "")
            {
                MessageBox.Show("Password cannot be empty");
            }
            else if (confirmPasswordTextBox.Text == "")
            {
                MessageBox.Show("Confirm Password cannot be empty");
            }
            else if (dateOfBirthDatePicker.Value.Date.ToString()==DateTime.Now.Date.ToString())
            {
                MessageBox.Show("Select a proper date of birth");
            }
            else if ((maleRadioButton.Checked==false) && (femaleRadioButton.Checked==false))
            {
                MessageBox.Show("Select a gender");
            }
            else if (bloodGroupComboBox.Text=="")
            {
                MessageBox.Show("Select a blood group");
            }
            else
            {
                if(passwordTextBox.Text!=confirmPasswordTextBox.Text)
                {
                    MessageBox.Show("Password and Confirm Password does not match");
                }
                else
                {
                    //SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OOP2[A]"].ConnectionString);
                    //connection.Open();
                    User user = new User();
                    user.Name = nameTextBox.Text;
                    user.Username = usernameTextBox.Text;
                    user.Email = emailTextBox.Text;
                    user.Password = passwordTextBox.Text;
                    user.DateOfBirth = dateOfBirthDatePicker.Text;
                    if(maleRadioButton.Checked)
                    {
                        user.Gender = "Male";
                    }
                    else
                    {
                        user.Gender = "Female";
                    }
                    user.BloodGroup = bloodGroupComboBox.Text;

                    //string sql = "INSERT INTO Users(Name,Username,Email,Password,DateOfBirth,Gender,BloodGroup) VALUES('"+user.Name+"','"+user.Username+"','"+user.Email+"','"+user.Password+"','"+user.DateOfBirth+"','"+user.Gender+"','"+user.BloodGroup+"')";
                    //SqlCommand command = new SqlCommand(sql,connection);
                    //int result = command.ExecuteNonQuery();
                    //connection.Close();
                    UserDataAccess userDataAccess = new UserDataAccess();
                    if(userDataAccess.UserRegister(user))
                    {
                        MessageBox.Show("User registered successfully");
                        Login login = new Login();
                        login.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Error in registration");
                    }
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
