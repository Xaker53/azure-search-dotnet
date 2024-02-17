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
using AzureSearchQuickstart_v11;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections;
using System.Threading;
using Microsoft.Extensions.Azure;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace AzureSearch.Quickstart


{
    public class Program
    {

        private AutoResetEvent uploadedToAzureSearch = new AutoResetEvent(false);
        private static CancellationTokenSource tokenSource = new CancellationTokenSource();
        private CancellationToken token = tokenSource.Token;
        static ConcurrentDictionaryFiles ParallelSearchFile;
        private static ThreadServer buffer;
        public void Start()
        {
            ManagementAzure managementAzure = new();
            managementAzure.Start();



            // Create a SearchIndexClient to send create/delete index commands


            // Create a SearchClient to load and query documents


            // Delete index if it exists
            Console.WriteLine("{0}", "Deleting index...\n");
            managementAzure.DeleteIndexIfExists();

            // Create index
            Console.WriteLine("{0}", "Creating index...\n");
            managementAzure.CreateIndex();

            //SearchClient ingesterClient = adminClient.GetSearchClient(indexName);

            //// Load documents
            Console.WriteLine("{0}", "Uploading documents...\n");
            UploadDocuments(managementAzure.IngesterClient);

            //// Wait 2 secondsfor indexing to complete before starting queries (for demo and console-app purposes only)
            //Console.WriteLine("Waiting for indexing...\n");
            //System.Threading.Thread.Sleep(2000);

            //// Call the RunQueries method to invoke a series of queries
            //Console.WriteLine("Starting queries...\n");
            //RunQueries(srchclient);

            // End the program
            Console.WriteLine("{0}", "Complete. Press any key to end this program...\n");
            //Console.ReadKey();
        }

        // Delete the hotels-quickstart index to reuse its name
        //private void DeleteIndexIfExists(string indexName, SearchIndexClient adminClient)
        //{
        //    adminClient.GetIndexNames();
        //    {
        //        adminClient.DeleteIndex(indexName);
        //    }
        //}
        // Create hotels-quickstart index

        public class Data
        {
            public string FileName { get; set; }
            public string FilePath { get; set; }
            public string FileText { get; set; }
        }

        //private void CreateIndex(string indexName, SearchIndexClient adminClient)
        //{
        //    FieldBuilder fieldBuilder = new FieldBuilder();
        //    var searchFields = fieldBuilder.Build(typeof(Files));

        //    var definition = new SearchIndex(indexName, searchFields);


        //    var suggester = new SearchSuggester("sg", new[] { "FileText" });


        //    definition.Suggesters.Add(suggester);

        //    adminClient.CreateOrUpdateIndex(definition);
        //}




        // Upload documents in a single Upload request.
        private async void UploadDocuments(SearchClient searchClient)
        {
            //DriveInfo[] driveInfos = DriveInfo.GetDrives();
            //var waitHandle = new AutoResetEvent(false);
            //var buffer = new ThreadServer(searchClient, waitHandle, 32000);
            //ParallelSearchFile = new ConcurrentDictionaryFiles((int)searchClient.GetDocumentCount().Value);
            //var TaskServer = Task.Run(
            //     async () =>
            //     {
            //         buffer.StartFlushSignals(TimeSpan.FromSeconds(5));
            //         while (waitHandle.WaitOne())
            //         {
            //             tokenSource.Token.ThrowIfCancellationRequested();
            //             await buffer.UploadToAzureSearch(uploadedToAzureSearch);
            //             Console.WriteLine($"Flushing files from buffer (thread: {Environment.CurrentManagedThreadId}):");
            //         }
            //     }, tokenSource.Token);

            //foreach (DriveInfo driveInfo in driveInfos)
            //{
            //    Files(driveInfo.ToString(), buffer);

            //    try
            //    {
            //        uploadedToAzureSearch.WaitOne();
            //        if (buffer.BatchCount == 0)
            //        {
            //            tokenSource.Cancel();
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        Handle exceptions if necessary
            //        Console.WriteLine($"Error uploading document: {ex.Message}");
            //    }
            //}

            //////////////////////////////////

            var waitHandle = new AutoResetEvent(false);
            buffer = new ThreadServer(searchClient, waitHandle, 32000);
            ParallelSearchFile = new ConcurrentDictionaryFiles((int)searchClient.GetDocumentCount().Value);
            Files(@"J:\\Ai");
            var TaskServer = Task.Run(
                 async () =>
                 {
                     buffer.StartFlushSignals(TimeSpan.FromMilliseconds(1));
                     while (waitHandle.WaitOne())
                     {
                         tokenSource.Token.ThrowIfCancellationRequested();
                         await buffer.UploadToAzureSearch(uploadedToAzureSearch);
                         Console.WriteLine($"Flushing files from buffer (thread: {Environment.CurrentManagedThreadId}):");
                     }
                 }, tokenSource.Token);

            Console.WriteLine($"Flushing files from buffer (thread: {Environment.CurrentManagedThreadId}):");


            uploadedToAzureSearch.WaitOne();
            if (buffer.BatchCount == 0)
            {
                tokenSource.Cancel();
            }
            ////////////////////////////////////////////////////////////////
            //try
            //{
            //    IndexDocumentsResult result = searchClient.IndexDocuments(batch);
            //}
            //catch (Exception)
            //{
            //    // If for some reason any documents are dropped during indexing, you can compensate by delaying and
            //    // retrying. This simple demo just logs the failed document keys and continues.
            //    Console.WriteLine("Failed to index some of the documents: {0}");
            //}
            /////
        }

        public static void Files(string filesDirectory)
        {
            ParallelSearchFile.ParallelFiles(filesDirectory, buffer);
        }



        ///////////////////////////////////////////////////////////

        //static public Dictionary<string, Data[]> Files(string filesDirectory)
        //{
        //    Dictionary<string, Data[]> myDictionary = new Dictionary<string, Data[]>();

        //    foreach (string filePath in Directory.GetFileSystemEntries(filesDirectory))
        //    {
        //        try
        //        {
        //            if (File.Exists(filePath))
        //            {
        //                string extension = Path.GetExtension(filePath);

        //                if (IsSupportedExtension(extension))
        //                {
        //                    string pageText = GetFileText(filePath, extension);

        //                    Data[] dataInfo = new Data[]
        //                    {
        //                        new Data { FilePath = filePath, FileName = Path.GetFileName(filePath), FileText = pageText.Replace("\n", "") }
        //                    };

        //                    myDictionary.Add(filePath, dataInfo);
        //                }
        //                else
        //                {
        //                    var data = new Data[]
        //                    {
        //                        new Data { FilePath = filePath, FileName = Path.GetFileName(filePath), FileText = "" }
        //                    };

        //                    myDictionary.Add(filePath, data);
        //                }
        //            }
        //            else
        //            {
        //                Dictionary<string, Data[]> subFile = Files(filePath);
        //                foreach (var info in subFile)
        //                {
        //                    myDictionary.Add(info.Key, info.Value);
        //                }
        //            }
        //        }
        //        catch
        //        {
        //            // Handle exceptions if needed
        //        }
        //    }

        //    return myDictionary;
        //}

        bool IsSupportedExtension(string extension)
        {
            string[] supportedExtensions = { ".pdf", ".docx", ".doc", ".txt" };

            return supportedExtensions.Contains(extension);
        }

        string GetFileText(string filePath, string extension)
        {
            string pageText = "";

            switch (extension)
            {
                case ".txt":
                    pageText = File.ReadAllText(filePath).Replace("\n", "").Replace("\r", " ");

                    break;
                case ".pdf":
                    pageText = ExtractTextFromPdf(filePath);

                    break;
                case ".docx":
                    //using (WordprocessingDocument docx = WordprocessingDocument.Open(filePath, true))
                    //{
                    //    var bodyX = docx.MainDocumentPart.Document.Body;
                    //    pageText = bodyX.InnerText;
                    //}

                    Document document = new Document();
                    document.LoadText(filePath);
                    pageText = document.GetText().Remove(0, 69).Replace("\r", "");
                    break;
                case ".doc":
                    Document doc = new Document();
                    doc.LoadFromFile(filePath);
                    pageText = doc.GetText().Remove(0, 69).Replace("\r", "");
                    break;
            }
            //Console.WriteLine(pageText.Length);
            //pageText= PopularWords.Result(pageText);
            //Console.WriteLine(pageText.Length);                ///////////need delete
            var rake = new Rake.Rake();
            var result = rake.Run(pageText.ToLower());
            pageText = string.Join(" ", result.Keys);

            return pageText;
        }

        string ExtractTextFromPdf(string filePath)
        {
            string pageText = "";

            using (PdfReader pdfReader = new PdfReader(filePath))
            {
                using (PdfDocument pdfDocument = new PdfDocument(pdfReader))
                {
                    int numPages = pdfDocument.GetNumberOfPages();
                    for (int pageNum = 1; pageNum <= numPages; pageNum++)
                    {
                        SimpleTextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                        pageText += PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(pageNum), strategy);
                    }
                }
            }

            return pageText;
        }


        //////////////////////////////////////////////////////////


        private void RunQueries(SearchClient srchclient)
        {
            SearchOptions options;
            SearchResults<Files> response;


            options = new SearchOptions();
            options.Select.Add("FileID");
            options.Select.Add("FileName");
            options.Select.Add("FileText");
            options.Select.Add("FilePath");
            response = srchclient.Search<Files>("оптимізації", options);

            WriteDocuments(response);
            // Query 1
            //Console.WriteLine("Query #1: name file\n");

            //options = new SearchOptions()
            //{
            //    IncludeTotalCount = true,
            //    Filter = "",
            //    OrderBy = { "" }
            //};

            //options.Select.Add("FileID");
            //options.Select.Add("FileName");
            //options.Select.Add("FileText");

            //response = srchclient.Search<Files>("*", options);
            //WriteDocuments(response);


            // Filters are typically used with facets to narrow results on OnClick events




        }
        // Write search results to console
        private void WriteDocuments(SearchResults<Files> searchResults)
        {
            foreach (SearchResult<Files> result in searchResults.GetResults())
            {
                Console.WriteLine(result.Document);
            }

            Console.WriteLine();
        }

        private void WriteDocuments(AutocompleteResults autoResults)
        {
            foreach (AutocompleteItem result in autoResults.Results)
            {
                Console.WriteLine(result.Text);
            }

            Console.WriteLine();
        }
    }
}
