using Azure.Search.Documents.Models;
using AzureSearch.Quickstart;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static AzureSearch.Quickstart.Program;

namespace AzureSearchQuickstart_v11
{
    class ConcurrentDictionaryFiles
    {
        private ThreadServer ThreadServer { get; set; }
        private int index = 0;

        
        public void ParallelFiles(string filesDirectory, ThreadServer threadServer)
        {
            this.ThreadServer = threadServer;
            
            Parallel.ForEach(Directory.GetFileSystemEntries(filesDirectory), filePath =>
            {
                try
                {
                    if (File.Exists(filePath))
                    {
                        string extension = Path.GetExtension(filePath);

                        if (IsSupportedExtension(extension))
                        {
                            GetFileText FileText = new GetFileText(filePath, extension);
                            string pageText = FileText.getPageText();
                            
                            AddIndex(Path.GetFileName(filePath),filePath,pageText.Replace("\n", ""));
                            Interlocked.Increment(ref index);
                            
                        }
                        //else
                        //{
                        //    AddIndex(Path.GetFileName(filePath), filePath);
                        //    Interlocked.Increment(ref index);
                        //}
                    }
                    else
                    {
                        Files(filePath, ThreadServer);
                    }

                }
                catch (Exception ex) 
                {
                    //Console.WriteLine(ex.Message);
                }

            });
        }


        private void AddIndex(string fileName,string filePath, string pageText = "")
        {
            ThreadServer.Add(IndexDocumentsAction.Upload(new Files
            {
                 // Assuming Files has a property ID
                FileID = $"{index}",
                FileName = $"{fileName}",
                FileText = $"{pageText}",
                FilePath = $"{filePath}"
            }));;

        }

        private bool IsSupportedExtension(string extension)
        {
            string[] supportedExtensions = { ".pdf", ".docx", ".doc", ".txt" };

            return supportedExtensions.Contains(extension);
        }
    }
}
