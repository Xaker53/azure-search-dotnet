using Core.Entities;
using Core.Entities.MappingProfiles;
using Newtonsoft.Json.Linq;
using System.Net;
using UserLoginIn.Interface;
using UserLoginIn.Requests;

namespace UserLoginIn
{
    public partial class MainPage : ContentPage
    {
        private readonly ILoginRequests _loginRequests;
        private readonly RegistrationsPage _registrationsPage;
        private readonly IServiceProvider _searchPage;
        private HttpResponseMessage result;
        private string JwtToken;
        private GlobalState _userRequest;

        public MainPage(ILoginRequests loginRequests, RegistrationsPage registrationsPage, IServiceProvider searchPage, GlobalState userRequest)
        {
            InitializeComponent();
            _loginRequests = loginRequests;
            _registrationsPage = registrationsPage;
            _searchPage = searchPage;
            _userRequest = userRequest;
        }

        private async void OnLoginClicked(object? sender, EventArgs e)
        {

            //if (!string.IsNullOrEmpty(UseremailEntry.Text))
            var userRequest = new UserLogin()
            {
                UserGmail = UseremailEntry.Text,
                Password = PasswordEntry.Text
            };

            result = await _loginRequests.LoginUser(userRequest);

            if (result == null)
                throw new Exception("Server returned null");

            try
            {
                if (result.StatusCode!= HttpStatusCode.OK) throw new HttpRequestException();
                var page = _searchPage.GetRequiredService<SearchPage>();
                _userRequest.JwtToken = await result.Content.ReadAsStringAsync();
                //JwtToken = await result.Content.ReadAsStringAsync();
                page.InTokenEmail(userRequest.UserGmail);
                await Navigation.PushAsync(page);
            }
            catch (HttpRequestException)
            {
                var error = await result.Content.ReadAsStringAsync();
                await DisplayAlert("ERROR", error, "OK");
            }
        }
            
            //var result = await _loginRequests.LoginUser(userRequest);
            //JwtToken = result.Content.ReadAsStringAsync().Result;
        

        private async void OnRegistrationClicked(object? sender, EventArgs e)
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
