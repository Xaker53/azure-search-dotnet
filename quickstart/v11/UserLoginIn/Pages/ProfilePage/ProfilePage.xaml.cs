
using System.Net;
using Azure;
using Core.Entities.MappingProfiles;
using Newtonsoft.Json;
using UserLoginIn.Interface;

namespace UserLoginIn;

public partial class ProfilePage : ContentPage
{
	private readonly IUpdateUserRequests _updateUserRequests;
    private readonly IDeleteUserRequests _deleteUserRequests;
    private GlobalState _UpdateUser;
    public ProfilePage(IUpdateUserRequests updateUser, IDeleteUserRequests deleteUser, GlobalState userInfo)
	{
		InitializeComponent();
		_updateUserRequests = updateUser;
        _deleteUserRequests = deleteUser;
        _UpdateUser = userInfo;

        BindingContext = _UpdateUser.CurrentUser;

    }

	private async void OnClickCancel(object? sender, EventArgs e)
	{
		await Navigation.PopAsync();
        Navigation.RemovePage(this);

    }

	private void OnClickShowPassword (object? sender, EventArgs e)
	{
        PasswordEntry.IsPassword = !PasswordEntry.IsPassword;

    }

	private async void OnSaveChanges(object? sender, EventArgs e)
	{
        try
        {

            _UpdateUser.CurrentUser.OtherGmail = GmailEntry.Text != _UpdateUser.CurrentUser.Gmail? GmailEntry.Text:null;
            _UpdateUser.CurrentUser.Password = PasswordEntry.Text == null? null : PasswordEntry.Text;

            var response = await _updateUserRequests.FetchToServer(_UpdateUser.CurrentUser, JwtTokenIn: _UpdateUser.JwtToken);
            response.EnsureSuccessStatusCode();
            if (response != null)
            {
                await DisplayAlert("Server:", "Success", "OK");

                if (!string.IsNullOrWhiteSpace(_UpdateUser.CurrentUser.OtherGmail))
                {
                    _UpdateUser.CurrentUser.Gmail = _UpdateUser.CurrentUser.OtherGmail;
                    _UpdateUser.CurrentUser.OtherGmail = null;
                }
                //Setup(_UpdateUser, _JwtToken);
                await Navigation.PopAsync();
            }

        }
        catch (HttpRequestException ex)
        {
            await DisplayAlert("Server:", ex.Message, "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error:", ex.Message, "OK");
        }
    }

    private async void OnDelete (object? sender, EventArgs e)
    {
        try
        {
            bool dialogResult = await DisplayAlert("Delete your account?", "Delete", "Yes", "No");
            if (dialogResult)
            {
                var response = await _deleteUserRequests.FetchToServer(_UpdateUser?.CurrentUser?.Gmail, _UpdateUser?.JwtToken);

                response?.EnsureSuccessStatusCode();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    await DisplayAlert("Server:", "Success delete", "OK");
                    _UpdateUser = new();
                    await Shell.Current.GoToAsync("//MainPage");

                }
            }
        }
        catch (HttpRequestException ex)
        {
            await DisplayAlert("Server:", ex.Message, "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error:", ex.Message, "OK");
        }

    }
}