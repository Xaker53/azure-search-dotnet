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
using WinFormsApp1.Interface;
using Core.Entities.MappingProfiles;
using System.Net;

namespace WinFormsApp1
{
    public partial class Registration : Form
    {

        private UserRequest userRequest = new UserRequest();
        public Registration()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void Registration_User_Button(object sender, EventArgs e)
        {
            userRequest.Name = Nickname.Text;
            userRequest.Gmail = Gmail.Text;
            userRequest.Password = Password.Text;

            IRegistrationRequests registrationRequests = new RegistrationRequests("https://localhost:7156/api/Create");
            var result = await registrationRequests.RegisterUser(userRequest);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Registration.ActiveForm.Close();
        }

        private void Nickname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
