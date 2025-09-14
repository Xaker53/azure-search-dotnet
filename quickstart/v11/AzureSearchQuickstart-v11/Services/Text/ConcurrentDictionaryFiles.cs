using Azure.Search.Documents.Models;
using AzureSearch.Quickstart;
using AzureSearchQuickstart_v11.Infrastructure.Search;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static AzureSearch.Quickstart.Program;

namespace AzureSearchQuickstart_v11.Services.Text
{
    class ConcurrentDictionaryFiles
    {
        private ThreadServer ThreadServer { get; set; }
        private int index;
        private string Method;
        static CancellationTokenSource cts = new();


        private ParallelOptions options;

        public ConcurrentDictionaryFiles()
        {
        }

        public ConcurrentDictionaryFiles(int Index, string Method)
        {
            index = Index;
            this.Method = Method;
            cts = new();
            options = new()
            {
                CancellationToken = cts.Token,
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };
        }
        public void ParallelFiles(string filesDirectory, ThreadServer threadServer)
        {
            ThreadServer ??= threadServer;
            try
            {
                Parallel.ForEach(Directory.GetFileSystemEntries(filesDirectory), options, filePath =>
                {

                    try
                    {
                        if (File.Exists(filePath))
                        {
                            string extension = Path.GetExtension(filePath);

                            if (IsSupportedExtension(extension))
                            {
                                GetFileText FileText = new GetFileText(filePath, extension, this.Method);
                                string pageText = FileText.getPageText();

                                AddIndex(Path.GetFileName(filePath), Path.GetFullPath(filePath), pageText.Replace("\n", ""));
                                //Interlocked.Increment(ref index);

                            }
                            else
                            {
                                //AddIndex(Path.GetFileName(filePath), Path.GetFullPath(filePath));
                                //Interlocked.Increment(ref index);
                            }
                        }
                        else
                        {
                            Files(filePath);
                        }

                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.Message);
                    }

                });
            }
            catch (Exception e)
            {
                
            }
            
        }


        private  void AddIndex(string fileName,string filePath, string pageText = "")
        {
            int currentIndex = Interlocked.Increment(ref index);
            ThreadServer.Add(IndexDocumentsAction.Upload(new Files
            {
                 // Assuming Files has a property ID
                FileID = $"{currentIndex}",
                FileName = $"{fileName}",
                FileText = $"{pageText}",
                FilePath = $"{filePath}"
            }));

        }

        public void Cancel()
        {
            cts.Cancel();
        }
        private bool IsSupportedExtension(string extension)
        {
            string[] supportedExtensions = { ".pdf", ".docx", ".doc", ".txt" };

            return supportedExtensions.Contains(extension);
        }
    }
}
