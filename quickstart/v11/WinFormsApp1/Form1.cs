using DocumentFormat.OpenXml.Wordprocessing;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        FolderBrowserDialog browserDialog;
        AzureSearch.Quickstart.ManagementAzure managementAzure = new();
        public Form1()
        {
            InitializeComponent();

            managementAzure.Start();
            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            FileSystemWatcher watcher = new FileSystemWatcher(@"\");
            
            watcher.EnableRaisingEvents = true;
            watcher.SynchronizingObject = this;
            watcher.IncludeSubdirectories = true;
            //watcher.Created += new FileSystemEventHandler(WatherCreated);
            watcher.Renamed += OnRenamed;
            watcher.Changed += OnChanger;
            watcher.Deleted += OnDeleted;
            //watcher.Created

        }


        private void button1_Click(object sender, EventArgs e)
        {
            browserDialog = new FolderBrowserDialog();
            folderBrowserDialog1.ShowDialog();

            var result = folderBrowserDialog1.SelectedPath;

            AzureSearch.Quickstart.Program program = new();
            program.Start();

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {

        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            managementAzure.Start();
            //managementAzure.RunQueries(@"J:\Ai\archive\A_Z Handwritten Data\Text Document.txt");

        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            string NewName = new string(e.Name.Reverse().TakeWhile(c => c != '\\').Reverse().ToArray());
            string OldName = new string(e.OldName.Reverse().TakeWhile(c => c != '\\').Reverse().ToArray());

            managementAzure.RunQueries(OldName, "Renamed", e.FullPath, NewName);
            label1.Text = $"old path {OldName}, new {e.FullPath}, file name {NewName}";
        }

        private void OnChanger(object sender, FileSystemEventArgs e)
        {
            string NameFile = new string(e.Name.Reverse().TakeWhile(c => c != '\\').Reverse().ToArray());
            managementAzure.RunQueries(NameFile, "Changer", PathFile:e.FullPath );
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            //string NameFile = new string(e.Name.Reverse().TakeWhile(c => c != '\\').Reverse().ToArray());
            //managementAzure.RunQueries(NameFile, "Deleted", PathFile: e.FullPath);
        }
    }
}
