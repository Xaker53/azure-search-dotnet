using Core.Entities;
using Core.Entities.MappingProfiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Requests;

namespace WinFormsApp1
{
    public partial class Login : Form
    {
        private UserLogin userRequest;
        private LoginRequests _loginRequests;
        private string JwtToken;
        public Login()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registration = new Registration();
            DialogResult result = registration.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show("Registration successful!");
            }
            else if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Registration cancelled.");
            }
        }

        private async void LoginUser_Button(object sender, EventArgs e)
        {
            userRequest = new UserLogin()
            {
                UserGmail = Email.Text,
                Password = Password.Text
            };

            _loginRequests = new LoginRequests("https://localhost:7156/api/Login");
            var result = await _loginRequests.LoginUser(userRequest);
            JwtToken = result.Content.ReadAsStringAsync().Result;
        }
    }
}
