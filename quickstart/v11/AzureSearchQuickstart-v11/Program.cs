using System;
using System.Collections.Generic;
using System.IO;
using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
///Install-Package itext7
 // Для .doc

using DocumentFormat.OpenXml.Packaging;

using Spire.Doc;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections;
using System.Threading;
using Microsoft.Extensions.Azure;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AzureSearchQuickstart_v11.Services.Text;
using AzureSearchQuickstart_v11.Infrastructure.Search;


namespace AzureSearch.Quickstart


{
    public class Program
    {

        private AutoResetEvent uploadedToAzureSearch = new AutoResetEvent(false);
        private static CancellationTokenSource tokenSource ;
        //private CancellationToken token = tokenSource.Token;
        static ConcurrentDictionaryFiles ParallelSearchFile;
        private static ThreadServer buffer;
        private ManagementAzure managementAzure;

        ~Program() 
        {
            tokenSource.Cancel();
        }


        public void CancelToken()
        {
            if (tokenSource != null)
            {
                tokenSource.Cancel();
                ParallelSearchFile.Cancel();
            }
        }

        public Program()
        {
            managementAzure = new();
            managementAzure.Start();
        }

        public void RecreateIndex()
        {
            managementAzure.DeleteIndexIfExists();
            managementAzure.CreateIndex();
        }
       

       
        // Upload documents in a single Upload request.
        public async void UploadDocuments(string PathFileSearch, string Method = "Rake")
        {
            var searchClient = this.managementAzure.IngesterClient;
            var waitHandle = new AutoResetEvent(false);
            buffer = new ThreadServer(searchClient, waitHandle, 32000);
            ParallelSearchFile = new ConcurrentDictionaryFiles((int)searchClient.GetDocumentCount().Value, Method);
            tokenSource = new();
 
            var TaskServer = Task.Run(
                 async () =>
                 {
                     buffer.StartFlushSignals(TimeSpan.FromMilliseconds(1));
                     while (waitHandle.WaitOne())
                     {
                         tokenSource.Token.ThrowIfCancellationRequested();
                         await buffer.UploadToAzureSearch(uploadedToAzureSearch);
                     }
                 }, tokenSource.Token);

            if (PathFileSearch.Length <= 0)
            {
                ScanAllDrive();
            }
            else
            {
                Files(Path.GetFullPath(PathFileSearch));
            }

            uploadedToAzureSearch.WaitOne();
            while (buffer.BatchCount == 0)
            {
                tokenSource.Cancel();
                break;
            }
           
        }


        private void ScanAllDrive()
        {
            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            foreach (DriveInfo driveInfo in driveInfos)
            {
                Files(driveInfo.ToString());

                try
                {
                    uploadedToAzureSearch.WaitOne();
                    if (buffer.BatchCount == 0)
                    {
                        tokenSource.Cancel();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error uploading document: {ex.Message}");
                }
            }
        }

        public static void Files(string filesDirectory)
        {
            ParallelSearchFile.ParallelFiles(filesDirectory, buffer);
        }

    }
}
