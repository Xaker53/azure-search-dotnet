using System.Net;
using Core.Entities.MappingProfiles;
using UserLoginIn.Interface;

namespace UserLoginIn;

public partial class RegistrationsPage : ContentPage
{
    private UserRequest userRequest;
    private readonly IRegistrationRequests _registrationRequests;
    public RegistrationsPage(IRegistrationRequests registrationRequests)
	{
		InitializeComponent();
        _registrationRequests = registrationRequests;
    }

	private async void OnRegisterClicked(object? sender, EventArgs e)
	{
        userRequest = new();
        userRequest.Name = NicknameEntry.Text;
        userRequest.Gmail = GmailEntry.Text;
        userRequest.Password = PasswordEntry.Text;

        
        try
        {
            var result = await _registrationRequests.RegisterUser(userRequest);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                //DialogResult = DialogResult.OK;
                await DisplayAlert("Success", "Registration successful!", "OK");
                NicknameEntry.Text = "";
                GmailEntry.Text = "";
                PasswordEntry.Text = "";
                await Navigation.PopAsync();

            }
            else
            {
                await DisplayAlert("ERROR", $"Something happened", "OK");
                await Navigation.PopAsync();
                //DialogResult = DialogResult.Cancel;
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("ERROR", $"Something happened", "OK");
        }
        
    }

	private async void OnBackClicked(object? sender, EventArgs e) 
	{
        await Navigation.PopAsync();
    }
}