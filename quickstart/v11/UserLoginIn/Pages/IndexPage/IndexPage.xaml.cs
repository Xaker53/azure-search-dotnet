
using Aspose.Words.XAttr;
using AzureSearch.Quickstart;
using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui.Storage;
using ICSharpCode.SharpZipLib.Core;



namespace UserLoginIn;

public partial class IndexPage : ContentPage
{

    private string _pathFile = "";
    private string _algorithm = "Rake";
    private CancellationTokenSource tokenSource;
    private Program program;


    public IndexPage()
	{
		InitializeComponent();
        AlgorithmPicker.SelectedItem = _algorithm;
        program = new();

    }

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
                program.UploadDocuments(_pathFile, _algorithm, RecoverableTextCheckBox.IsChecked);

            }, tokenSource.Token);
            ButtonStartIndex.IsEnabled = true;
            ButtonStartIndex.BackgroundColor = Color.Parse("#6366F1");
            await DisplayAlert("Succes", "Indexing is complete", "OK");
        }
        else
        {
            await DisplayAlert("Notes", "You need to select a folder or scan the entire system", "OK");
        }
    }

    private async void OnDelete (object sender, EventArgs e)
    {
        bool dialogResult = await DisplayAlert("Delete all index?", "Delete", "Yes","No");
        if (dialogResult)
        {
            program.RecreateIndex();
            await DisplayAlert("Succes", "Indexing is delete", "OK");
        }
    }

    private async void OnStop (object sender, EventArgs e)
    {
        if (tokenSource != null)
        {
            program.CancelToken();
            tokenSource?.Cancel();
            await DisplayAlert("Succes", "Indexing is stop", "OK");
        }
    }
}