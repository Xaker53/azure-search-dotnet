
using Azure;
using Core.Entities.MappingProfiles;
using Newtonsoft.Json;
using UserLoginIn.Interface;

namespace UserLoginIn;

public partial class ProfilePage : ContentPage
{
	private string _JwtToken;
	private readonly IUpdateUserRequests _updateUserRequests;
	private UserRequest _UpdateUser;
    public ProfilePage(IUpdateUserRequests updateUser)
	{
		InitializeComponent();
		_updateUserRequests = updateUser;
	}

	public void Setup(UserRequest userRequest, string JwtToken)
	{
        //GmailEntry.Placeholder = Gmail;
        //NameEntry.Placeholder = name;
        //PasswordEntry.Placeholder = password;

        //      EmptyUserName.Text = name;
        _UpdateUser = userRequest;
        BindingContext = _UpdateUser;

        _JwtToken = JwtToken;

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

            _UpdateUser.OtherGmail = GmailEntry.Text != _UpdateUser.Gmail? GmailEntry.Text:null;
            _UpdateUser.Password = PasswordEntry.Text == null? null : PasswordEntry.Text;

            var response = await _updateUserRequests.FetchToServer(_UpdateUser, JwtTokenIn: _JwtToken);
            response.EnsureSuccessStatusCode();
            if (response != null)
            {
                await DisplayAlert("Server:", "Success", "OK");

                if (!string.IsNullOrWhiteSpace(_UpdateUser.OtherGmail))
                {
                    _UpdateUser.Gmail = _UpdateUser.OtherGmail;
                    _UpdateUser.OtherGmail = null;
                }
                Setup(_UpdateUser, _JwtToken);
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