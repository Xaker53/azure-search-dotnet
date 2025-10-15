
using AzureSearch.Quickstart;
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

    public SearchPage(ISearchRequests searchRequests)
    {
        InitializeComponent();
        _searchRequests = searchRequests;
    }

    private async void SearchEntry_TextChanged(object sender, EventArgs e)
    {
        _debounceCts?.Cancel();
        _debounceCts = new CancellationTokenSource();
        var token = _debounceCts.Token;

        _ = Task.Run(async () =>
        {
            try
            {
                await Task.Delay(500, token);
                if (!token.IsCancellationRequested)
                {
                    await MainThread.InvokeOnMainThreadAsync(async () =>
                    {
                        var test = await _searchRequests.FetchToServer(SearchEmpty.Text);
                        var items = JsonConvert.DeserializeObject<List<Files>>(test) ?? new();
                        ResultInfo.ItemsSource = items;
                    });
                }
            }
            catch (TaskCanceledException) { }
        }, token);
    }

    
}
