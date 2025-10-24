namespace UserLoginIn;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
	}

	public void Setup(string Gmail, string name, string password)
	{
		GmailEntry.Placeholder = Gmail;
		NameEntry.Placeholder = name;
		PasswordEntry.Placeholder = password;

        EmptyUserName.Text = name;

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
}