using Core.Entities;
using Core.Entities.MappingProfiles;
using Newtonsoft.Json.Linq;
using UserLoginIn.Interface;
using UserLoginIn.Requests;

namespace UserLoginIn
{
    public partial class MainPage : ContentPage
    {
        private readonly ILoginRequests _loginRequests;
        private readonly RegistrationsPage _registrationsPage;
        private HttpResponseMessage result;
        private string JwtToken;

        public MainPage(ILoginRequests loginRequests, RegistrationsPage registrationsPage)
        {
            InitializeComponent();
            _loginRequests = loginRequests;
            _registrationsPage = registrationsPage;
        }

        private async void OnLoginClicked(object? sender, EventArgs e)
        {
            var userRequest = new UserLogin()
            {
                UserGmail = UseremailEntry.Text,
                Password = PasswordEntry.Text
            };

            try
            {
                result = await _loginRequests.LoginUser(userRequest);
                if (result == null)
                {
                    throw new Exception("Server return null");
                }
                JwtToken = result.Content.ReadAsStringAsync().Result;
            }
            catch(Exception error)
            {
                await DisplayAlert("ERROR",$"{error.Message}", "OK");
            }
            //var result = await _loginRequests.LoginUser(userRequest);
            //JwtToken = result.Content.ReadAsStringAsync().Result;
        }

        private async void OnRegistrationClicked (object? sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(_registrationsPage);
            }
            catch (Exception error)
            {
                DisplayAlert("ERROR", $"{error.Message}", "OK");
            }

            //await Navigation.PushAsync(_registrationsPage);

            //var registration = new Registration();
            //DialogResult result = registration.ShowDialog();

            //if (result == DialogResult.OK)
            //{
            //    MessageBox.Show("Registration successful!");
            //}
            //else if (result == DialogResult.Cancel)
            //{
            //    MessageBox.Show("Registration cancelled.");
            //}
        }
        //private void OnCounterClicked(object? sender, EventArgs e)
        //{
        //    count++;

        //    if (count == 1)
        //        CounterBtn.Text = $"Clicked {count} time";
        //    else
        //        CounterBtn.Text = $"Clicked {count} times";

        //    SemanticScreenReader.Announce(CounterBtn.Text);
        //}
    }
}
