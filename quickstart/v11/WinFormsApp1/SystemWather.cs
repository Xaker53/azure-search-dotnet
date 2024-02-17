using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    class SystemWather
    {
        private FileSystemWatcher watcher;
        private string FilePath;

        private bool OnWatcher = false;
        private bool Synchronizing = false;
        private bool SearchSubdirectories = false;


        private string serviceName = "search53";
        private string apiKey = "FVSYI2BfI4x26m6LDy55Ix4vaQqxvKlX7SKCxtmJf2AzSeCxpQRV";
        private string indexName = "hquickstart";

        public SystemWather(bool OnWatcher, bool Synchronizing, bool SearchSubdirectories, string filePath)
        {
            this.FilePath ??= filePath;
            this.OnWatcher = OnWatcher;
            this.Synchronizing = Synchronizing; 
            this.SearchSubdirectories = SearchSubdirectories;

        }


    }
}
