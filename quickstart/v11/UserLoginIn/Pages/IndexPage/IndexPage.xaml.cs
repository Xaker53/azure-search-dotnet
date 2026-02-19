
using System.Net;
using Aspose.Words.XAttr;
using AzureSearch.Quickstart;
using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui.Storage;
using Core.Entities.MappingProfiles;
using ICSharpCode.SharpZipLib.Core;
using Newtonsoft.Json.Linq;
using UserLoginIn.Interface;



namespace UserLoginIn;

public partial class IndexPage : ContentPage
{

    private string _pathFile = "";
    private string _algorithm = "Rake";
    private readonly IDeleteIndexRequest _DeleteIndex;
    private CancellationTokenSource tokenSource;
    private AzureSearch.Quickstart.Program program;

    private readonly IServiceProvider _pages;
    //private UserRequest _userRequest;
    //private string _JwtToken;

    private GlobalState _userRequest;


    public IndexPage(IServiceProvider Pages, GlobalState UserInfo, IDeleteIndexRequest deleteIndex)
	{
		InitializeComponent();
        AlgorithmPicker.SelectedItem = _algorithm;
        _DeleteIndex = deleteIndex;
        program = new();
        _pages = Pages;
        _userRequest = UserInfo;
        BindingContext = _userRequest.CurrentUser;

    }


    //public void Setup(UserRequest userRequest, string JwtToken)
    //{
    //    _userRequest = userRequest;
    //    BindingContext = _userRequest;
    //    _JwtToken = JwtToken;

    //}

    private void OnScanAllSystemChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            FilePathEntry.Text = "";
            _pathFile = "";
        }
    }

    private void OnScanAllSystemLabelTapped(object sender, EventArgs e)
    {
        ScanAllSystemCheckBox.IsChecked = !ScanAllSystemCheckBox.IsChecked;
    }

    private void OnRecoverableTextChanged(object sender, CheckedChangedEventArgs e)
    {
        
    }

    private async void OnSelectFolderClick (object sender, EventArgs e)
    {
        var pick = await FolderPicker.Default.PickAsync(default);
        if (pick.Folder != null)
        {
            _pathFile = pick.Folder.Path;
            FilePathEntry.Text = _pathFile;
            ScanAllSystemCheckBox.IsChecked = false;
        }
    }


    private async void OnStartIndex (object sender, EventArgs e)
    {
        if (ScanAllSystemCheckBox.IsChecked ||File.Exists(FilePathEntry.Text) ||Directory.Exists(FilePathEntry.Text))
        {
            //IsBusy = true;
            _algorithm = AlgorithmPicker.SelectedItem.ToString();
            tokenSource = new();
            ButtonStartIndex.IsEnabled = false;
            ButtonStartIndex.BackgroundColor = Colors.Gray;
            await Task.Run(() =>
            {
                tokenSource.Token.ThrowIfCancellationRequested();
                program.UploadDocuments(_pathFile, _userRequest?.CurrentUser?.UserId, _algorithm, RecoverableTextCheckBox.IsChecked);

            }, tokenSource.Token);
            ButtonStartIndex.IsEnabled = true;
            ButtonStartIndex.BackgroundColor = Color.Parse("#6366F1");
            await DisplayAlertAsync("Succes", "Indexing is complete", "OK");
        }
        else
        {
            await DisplayAlertAsync("Notes", "You need to select a folder or scan the entire system", "OK");
        }
    }

    private async void OnDelete (object sender, EventArgs e) //delete all index!!!!!!!!!
    {
        bool dialogResult = await DisplayAlertAsync("Delete all index?", "Delete", "Yes","No");
        if (dialogResult)
        {
            var result =  await _DeleteIndex.TryCatch(_userRequest?.CurrentUser?.Gmail, JwtToken: _userRequest?.JwtToken);
            //program.RecreateIndex();
            if (result?.StatusCode == HttpStatusCode.OK)
            {
                await DisplayAlertAsync("Succes", "Indexing is delete", "OK");
            }
            else
            {
                await DisplayAlertAsync("ERROR", "Indexing is not delete", "OK");
            }

        }
    }

    private async void OnStop (object sender, EventArgs e)
    {
        if (tokenSource != null)
        {
            program.CancelToken();
            tokenSource?.Cancel();
            await DisplayAlertAsync("Succes", "Indexing is stop", "OK");
            ButtonStartIndex.IsEnabled = true;
            ButtonStartIndex.BackgroundColor = Color.Parse("#6366F1");
        }
    }

    private async void OnTappedProfile(object sender, EventArgs e)
    {
        try
        {
            var page = _pages.GetRequiredService<ProfilePage>();
            //page.Setup(_userRequest, JwtToken);
            page.Disappearing += OnProfilePageClosed;
            await Navigation.PushAsync(page);
            //EnterNameUser();
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("ERROR", $"null", "ok");
        }
    }

    private void OnProfilePageClosed(object sender, EventArgs e)
    {
        var page = sender as ProfilePage;
        if (page != null)
        {
            page.Disappearing -= OnProfilePageClosed;
        }

        BindingContext = null;
        BindingContext = _userRequest.CurrentUser;
    }
}