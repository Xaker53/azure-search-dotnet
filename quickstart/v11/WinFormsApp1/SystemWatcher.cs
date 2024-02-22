using AzureSearch.Quickstart;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace WinFormsApp1
{
    class SystemWatcher
    {
        private FileSystemWatcher watcher;
        public string TextLabel = "";
        private List<EventArgs> textFiles = new();

        private AzureSearch.Quickstart.AzureSendingModifiedFiles azureSending;
        private AzureSearchQuickstart_v11.GetFileText getFileText;


        public SystemWatcher(System.ComponentModel.ISynchronizeInvoke? synchronize)
        {
            azureSending = new AzureSendingModifiedFiles();
            watcher = new FileSystemWatcher(@"\");
            watcher.EnableRaisingEvents = true;
            //watcher.SynchronizingObject = synchronize;
            watcher.IncludeSubdirectories = true;
            
            watcher.Renamed += OnRenamed;
            watcher.Changed += OnChanger;
            watcher.Deleted += OnDeleted;
            watcher.Created += OnCreated;
            watcher.Error += new ErrorEventHandler(OnError);

        }

        private void OnError(object sender, ErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        ~SystemWatcher()
        {

        }


        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            string NewName = Path.GetFileName(e.FullPath);
            string OldName = Path.GetFileName(e.OldName);
            //textFiles.Add(e);

            azureSending.ConnectSearchFiles(e.OldFullPath);
            Renamed(e);



            TextLabel = $"old path {OldName}, new {e.FullPath}, file name {NewName}";
        }

        private void OnChanger(object sender, FileSystemEventArgs e)
        {
            //textFiles.Add(e);
            azureSending.ConnectSearchFiles(e.FullPath);
            Changer(e);
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            //textFiles.Add(e);
            string pathFile = Path.GetFullPath(e.FullPath);
            if (IsSupportedExtension(Path.GetExtension(pathFile)))
            {
                //getFileText = new(pathFile, Path.GetExtension(pathFile));

                azureSending.AmendedDocument.FileID = azureSending.LastIndexDocument;
                azureSending.AmendedDocument.FileName = $"{Path.GetFileName(e.FullPath)}";
                //azureSending.AmendedDocument.FileText = getFileText.getPageText();
                azureSending.AmendedDocument.FilePath = pathFile;
                azureSending.SendingInformation();
            }

            TextLabel = "Created: "+e.FullPath;
        }


        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            //textFiles.Add(e);
            //managementAzure.RunQueries(e.FullPath, "Deleted", PathFile: e.FullPath);
        }


        private void Renamed(RenamedEventArgs e)
        {
            if (azureSending.GetAnswer)
            {
                string NewName = Path.GetFileName(e.FullPath);
                //AzureSearchQuickstart_v11.GetFileText getFileText = new(GetPath, Path.GetExtension(GetPath));
                azureSending.AmendedDocument.FileName = $"{NewName}";
                azureSending.AmendedDocument.FilePath = Path.GetFullPath(e.FullPath);
                azureSending.SendingInformation();
            }
        }

        private void Changer(FileSystemEventArgs e)
        {
            if (azureSending.GetAnswer)
            {
                if (IsSupportedExtension(Path.GetExtension(azureSending.GetPath)))
                {
                    if (azureSending.GetPath == Path.GetFullPath(azureSending.AmendedDocument.FilePath))
                    {
                        getFileText = new(azureSending.GetPath, Path.GetExtension(azureSending.GetPath));

                        azureSending.AmendedDocument.FileText = getFileText.getPageText();
                        azureSending.SendingInformation();
                    }
                    //else if ()
                    //else if (Path.GetFullPath(PathFile) != Path.GetFullPath(test.FilePath))
                    //{
                    //    test.FilePath = PathFile;
                    //    this.resultSearch.Add(test);
                    //    SendRequest();
                    //}

                }
            }
        }


        private bool IsSupportedExtension(string extension)
        {
            string[] supportedExtensions = { ".pdf", ".docx", ".doc", ".txt" };

            return supportedExtensions.Contains(extension);
        }
    }
}
