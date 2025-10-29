
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using Azure;
using AzureSearch.Quickstart;
using Core.Entities.MappingProfiles;
using DocumentFormat.OpenXml.Office2016.Drawing.Charts;
using Newtonsoft.Json;
using UserLoginIn.Interface;
using UserLoginIn.Requests;

namespace UserLoginIn;

public partial class SearchPage : ContentPage, INotifyPropertyChanged
{
    private CancellationTokenSource _debounceCts;

    private readonly ISearchRequests _searchRequests;
    private readonly IDecompression _decompression;
    private readonly IGetUserRequests _getUserRequests;
    private readonly IServiceProvider _pages;
    private GlobalState _userRequest;
    private string _Email;


    public void InTokenEmail (string Email)
    {
        _Email = Email ?? string.Empty;
        EnterNameUser();
    }

    public SearchPage(ISearchRequests searchRequests, IDecompression decompression, IGetUserRequests getUserRequests, IServiceProvider Pages, GlobalState userInfo)
    {
        InitializeComponent();
        _searchRequests = searchRequests;
        _decompression = decompression;
        _getUserRequests = getUserRequests;
        _userRequest = userInfo;
        EnterNameUser();
        _pages = Pages;
    }

    private async void EnterNameUser()
    {
        var response = await _getUserRequests.FetchToServer(_Email, _userRequest.JwtToken);
        try
        {
            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _userRequest.CurrentUser = JsonConvert.DeserializeObject<UserRequest>(await response.Content.ReadAsStringAsync());
                BindingContext = _userRequest.CurrentUser;
            }
            
        }
        catch (HttpRequestException ex)
        {
            DisplayAlert("Server:", ex.Message, "OK");
        }
        
    }

    private async void SearchEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        _debounceCts?.Cancel();
        var cts = _debounceCts = new CancellationTokenSource();

        try
        {
            await Task.Delay(500, cts.Token);
            if (cts.IsCancellationRequested) return;

            var query = e.NewTextValue; 
            if (query.Length != 0)
            {
                var json = await _searchRequests.FetchToServer(query, _userRequest.JwtToken);
                var items = JsonConvert.DeserializeObject<List<Files>>(json) ?? new();

                ResultInfo.ItemsSource = items;
            }
        }
        catch (TaskCanceledException)
        {
            
        }
    }

    private void OnFileNameTapped (object sender, EventArgs e)
    {
        if (sender is Label lbl)
        {
            DisplayAlert("File name", lbl.Text, "OK");
        }
    }

    private void OnTextTapped (object sender, EventArgs e)
    {
        if (sender is Label lbl)
        {
            DisplayAlert("File text", lbl.Text, "OK");
        }
    }

    private async void OnPathTapped(object sender, EventArgs e)
    {
        if (sender is Label lbl && lbl.BindingContext is Files item)
        {
            if (Environment.MachineName != item.IndexerName )
            {
                await DisplayAlert("ERROR", $"is not you enviroment {item.IndexerName}. You name: {Environment.MachineName}", "ok");
                var result = await _decompression.DecompressionFile(item.FileRecoveryText);
                await DisplayAlert("Decompression text", result, "OK");
            }
            else if (!File.Exists(item.FilePath))
            {
                await DisplayAlert("ERROR", $"File not found: {item.FilePath}.", "ok");
                await DisplayAlert("Decompression text", await _decompression.DecompressionFile(item.FileRecoveryText), "OK");
            }
            else if (Environment.MachineName == item.IndexerName && File.Exists(item.FilePath))
            {
                OpenPathAsync(item.FilePath);
            }
        }
    }


    private async void OnTappedProfile (object sender, EventArgs e)
    {
        try
        {
            var page = _pages.GetRequiredService<ProfilePage>();

            page.Disappearing += OnProfilePageClosed;
            await Navigation.PushAsync(page);

        }
        catch (Exception ex)
        {
            await DisplayAlert("ERROR", $"null", "ok");
        }
        
        
    }

    private void OnExitClick (object sender, EventArgs e)
    {
        Navigation.RemovePage(this);
       
    }

    private async void OnIndex_Files(object sender, EventArgs e)
    {
        var page = _pages.GetRequiredService<IndexPage>();
        await Navigation.PushAsync(page);
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

    private async Task OpenPathAsync(string path)
    {
#if WINDOWS
    if (File.Exists(path))
    {
        System.Diagnostics.Process.Start("explorer.exe", path);
    }
    else
    {
        await DisplayAlert("Ошибка", "Файл не найден или недоступен", "OK");
    }


#else
        if (File.Exists(path))
        {
            await Launcher.OpenAsync(new OpenFileRequest
            {
                File = new ReadOnlyFile(path)
            });
        }
        else
        {
            await DisplayAlert("Ошибка", "Файл не найден или недоступен", "OK");
        }
#endif
    }


}
