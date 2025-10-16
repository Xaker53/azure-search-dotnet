
using AzureSearch.Quickstart;
using DocumentFormat.OpenXml.Office2016.Drawing.Charts;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using UserLoginIn.Interface;
using UserLoginIn.Requests;

namespace UserLoginIn;

public partial class SearchPage : ContentPage
{
    private CancellationTokenSource _debounceCts;

    private readonly ISearchRequests _searchRequests;
    private readonly IDecompression _decompression;

    public SearchPage(ISearchRequests searchRequests, IDecompression decompression)
    {
        InitializeComponent();
        _searchRequests = searchRequests;
        _decompression = decompression;
    }

    //private async void SearchEntry_TextChanged(object sender, EventArgs e)
    //{
    //    _debounceCts?.Cancel();
    //    _debounceCts = new CancellationTokenSource();
    //    var token = _debounceCts.Token;

    //    _ = Task.Run(async () =>
    //    {
    //        try
    //        {
    //            await Task.Delay(500, token);
    //            if (!token.IsCancellationRequested)
    //            {
    //                await MainThread.InvokeOnMainThreadAsync(async () =>
    //                {
    //                    var test = await _searchRequests.FetchToServer(SearchEmpty.Text);
    //                    var items = JsonConvert.DeserializeObject<List<Files>>(test) ?? new();
    //                    ResultInfo.ItemsSource = items;
    //                });
    //            }
    //        }
    //        catch (TaskCanceledException) { }
    //    }, token);
    //}

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
                var json = await _searchRequests.FetchToServer(query);
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
            if (Environment.MachineName != item.IndexerName)
            {
                await DisplayAlert("ERROR", $"is not you enviroment {item.IndexerName}. You name: {Environment.MachineName}", "ok");
                var result = await _decompression.DecompressionFile(item.FileRecoveryText);
                DisplayAlert("Decompression text", result, "OK");
            }else if (Environment.MachineName == item.IndexerName)
            {
                OpenPathAsync(item.FilePath);
            }
        }
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
