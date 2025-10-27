using ICSharpCode.SharpZipLib.Core;
using CommunityToolkit.Maui.Storage;


namespace UserLoginIn;

public partial class IndexPage : ContentPage
{

    private string pathFile = "";
    private string algorithm = "Rake";
    private CancellationTokenSource tokenSource;

    public IndexPage()
	{
		InitializeComponent();
        AlgorithmPicker.SelectedItem = algorithm;

    }

    private void OnScanAllSystemChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            FilePathEntry.Text = "";
            pathFile = "";
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
            pathFile = pick.Folder.Path;
            FilePathEntry.Text = pathFile;
            ScanAllSystemCheckBox.IsChecked = false;
        }
    }
}