using AzureSearch.Quickstart;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace WinFormsApp1
{
    class SystemWather: AzureSearch.Quickstart.AzureSendingModifiedFiles
    {
        private FileSystemWatcher watcher;
        public string TextLabel = "";

        public SystemWather(System.ComponentModel.ISynchronizeInvoke? synchronize)
        {
            FileSystemWatcher watcher = new FileSystemWatcher(@"\");
            watcher.EnableRaisingEvents = true;
            watcher.SynchronizingObject = synchronize;
            watcher.IncludeSubdirectories = true;
            
            watcher.Renamed += OnRenamed;
            watcher.Changed += OnChanger;
            watcher.Deleted += OnDeleted;
            watcher.Created += OnCreated;

        }


        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            string NewName = Path.GetFileName(e.FullPath);
            string OldName = Path.GetFileName(e.OldName);
            if (Path.Exists(e.FullPath))
            {
                ConnectSearchFiles(e.OldFullPath);
                Renamed(e);
            }
            

            TextLabel = $"old path {OldName}, new {e.FullPath}, file name {NewName}";
        }

        private void OnChanger(object sender, FileSystemEventArgs e)
        {
            ConnectSearchFiles(e.FullPath);
            Changer(e);
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            TextLabel = "Created: "+e.FullPath;
        }


        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            //managementAzure.RunQueries(e.FullPath, "Deleted", PathFile: e.FullPath);
        }


        private void Renamed(RenamedEventArgs e)
        {
            if (GetAnswer)
            {
                string NewName = Path.GetFileName(e.FullPath);
                //AzureSearchQuickstart_v11.GetFileText getFileText = new(GetPath, Path.GetExtension(GetPath));
                AmendedDocument.FileName = $"{NewName}";
                AmendedDocument.FilePath = Path.GetFullPath(e.FullPath);
                SendingInformation();
            }
        }

        private void Changer(FileSystemEventArgs e)
        {
            if (GetAnswer)
            {
                if (IsSupportedExtension(Path.GetExtension(GetPath)))
                {
                    if (GetPath == Path.GetFullPath(AmendedDocument.FilePath))
                    {
                        AzureSearchQuickstart_v11.GetFileText getFileText = new(GetPath, Path.GetExtension(GetPath));

                        AmendedDocument.FileText = getFileText.getPageText();
                        SendingInformation();
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
