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
    class Program
    {

        static private AutoResetEvent uploadedToAzureSearch = new AutoResetEvent(false);
        static private CancellationTokenSource tokenSource = new CancellationTokenSource();
        static CancellationToken token = tokenSource.Token;
        static void Main(string[] args)
        {
            string serviceName = "search53";
            string apiKey = "FVSYI2BfI4x26m6LDy55Ix4vaQqxvKlX7SKCxtmJf2AzSeCxpQRV";
            string indexName = "hquickstart";

            // Create a SearchIndexClient to send create/delete index commands
            Uri serviceEndpoint = new Uri($"https://{serviceName}.search.windows.net/");
            AzureKeyCredential credential = new AzureKeyCredential(apiKey);
            SearchIndexClient adminClient = new SearchIndexClient(serviceEndpoint, credential);

            // Create a SearchClient to load and query documents
            SearchClient srchclient = new SearchClient(serviceEndpoint, indexName, credential);

            // Delete index if it exists
            Console.WriteLine("{0}", "Deleting index...\n");
            DeleteIndexIfExists(indexName, adminClient);

            // Create index
            Console.WriteLine("{0}", "Creating index...\n");
            CreateIndex(indexName, adminClient);

            SearchClient ingesterClient = adminClient.GetSearchClient(indexName);

            // Load documents
            Console.WriteLine("{0}", "Uploading documents...\n");
            UploadDocuments(ingesterClient);

            // Wait 2 secondsfor indexing to complete before starting queries (for demo and console-app purposes only)
            Console.WriteLine("Waiting for indexing...\n");
            System.Threading.Thread.Sleep(2000);

            // Call the RunQueries method to invoke a series of queries
            Console.WriteLine("Starting queries...\n");
            RunQueries(srchclient);

            // End the program
            Console.WriteLine("{0}", "Complete. Press any key to end this program...\n");
            Console.ReadKey();
        }

        // Delete the hotels-quickstart index to reuse its name
        private static void DeleteIndexIfExists(string indexName, SearchIndexClient adminClient)
        {
            adminClient.GetIndexNames();
            {
                adminClient.DeleteIndex(indexName);
            }
        }
        // Create hotels-quickstart index

        public class Data
        {
            public string FileName { get; set; }
            public string FilePath { get; set; }
            public string FileText { get; set; }
        }

        private static void CreateIndex(string indexName, SearchIndexClient adminClient)
        {
            FieldBuilder fieldBuilder = new FieldBuilder();
            var searchFields = fieldBuilder.Build(typeof(Files));

            var definition = new SearchIndex(indexName, searchFields);


            var suggester = new SearchSuggester("sg", new[] { "FileText" });


            definition.Suggesters.Add(suggester);

            adminClient.CreateOrUpdateIndex(definition);
        }



        
        // Upload documents in a single Upload request.
        private static async void UploadDocuments(SearchClient searchClient)
        {
            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            //ConcurrentQueue<IndexDocumentsAction<Files>> batch = new ConcurrentQueue<IndexDocumentsAction<Files>>();
            var waitHandle = new AutoResetEvent(false);
            var buffer = new ThreadServer(searchClient, waitHandle, 32000);

            var TaskServer = Task.Run(
                 async () =>
                 {
                     var waitHandle = new AutoResetEvent(false);
                     buffer.StartFlushSignals(TimeSpan.FromMinutes(1));
                     while (waitHandle.WaitOne())
                     {
                         tokenSource.Token.ThrowIfCancellationRequested();
                         await buffer.UploadToAzureSearch(uploadedToAzureSearch);
                         Console.WriteLine($"Flushing files from buffer (thread: {Environment.CurrentManagedThreadId}):");
                     }
                 }, tokenSource.Token);
            foreach (DriveInfo driveInfo in driveInfos)
            {
                var myDictor = Files(driveInfo.ToString());
                int it = 0;
                //var batch = new List<IndexDocumentsAction<Files>>();
                foreach (var info in myDictor)
                {
                    foreach (var file in info.Value)
                    {
                        buffer.Add(IndexDocumentsAction.Upload(new Files
                        {
                            FileID = $"{it}", // Assuming Files has a property ID
                            FileName = $"{file.FileName}",
                            FileText = $"{file.FileText}",
                            FilePath = $"{file.FilePath}"
                        }));

                        it++;
                    }
                }

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
                    // Handle exceptions if necessary
                    Console.WriteLine($"Error uploading document: {ex.Message}");
                }
            }

            //////////////////////////////////
            //var myDictor = Files(@"J:\\Ai");
            //int it = 0;
            //ConcurrentQueue<IndexDocumentsAction<Files>> batch = new ConcurrentQueue<IndexDocumentsAction<Files>>();

            //var buffer = new ThreadServer(searchClient);

            //var TaskServer = Task.Run(
            //    async () =>
            //    {

            //        var waitHandle = new AutoResetEvent(false);
            //        buffer.StartFlushSignals(TimeSpan.FromSeconds(5), waitHandle);
            //        while (waitHandle.WaitOne())
            //        {
            //            tokenSource.Token.ThrowIfCancellationRequested();
            //            await buffer.UploadToAzureSearch(uploadedToAzureSearch, batch);
            //            Console.WriteLine($"Flushing files from buffer (thread: {Environment.CurrentManagedThreadId}):");
            //        }
            //    }, tokenSource.Token);

            //foreach (var info in myDictor)
            //{

            //    foreach (var file in info.Value)
            //    {
            //        batch.Enqueue(
            //        IndexDocumentsAction.Upload(new Files
            //        {
            //            FileID = $"{it}", // Assuming Files has a property ID
            //            FileName = $"{file.FileName}",
            //            FileText = $"{file.FileText}",
            //            FilePath = $"{file.FilePath}"
            //        }));

            //        it++;
            //    }
            //}
            //Console.WriteLine($"Flushing files from buffer (thread: {Environment.CurrentManagedThreadId}):");
            //uploadedToAzureSearch.WaitOne();
            //if (batch.Count == 0)
            //{
            //    tokenSource.Cancel();
            //}
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

        static public ConcurrentDictionary<string, Data[]> Files(string filesDirectory)
        {
            ConcurrentDictionaryFiles ParallelD = new ConcurrentDictionaryFiles(filesDirectory);
            return ParallelD.Dictionary();
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

        static bool IsSupportedExtension(string extension)
        {
            string[] supportedExtensions = { ".pdf", ".docx", ".doc", ".txt" };

            return supportedExtensions.Contains(extension);
        }

        static string GetFileText(string filePath, string extension)
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

        static string ExtractTextFromPdf(string filePath)
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


        private static void RunQueries(SearchClient srchclient)
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
        private static void WriteDocuments(SearchResults<Files> searchResults)
        {
            foreach (SearchResult<Files> result in searchResults.GetResults())
            {
                Console.WriteLine(result.Document);
            }

            Console.WriteLine();
        }

        private static void WriteDocuments(AutocompleteResults autoResults)
        {
            foreach (AutocompleteItem result in autoResults.Results)
            {
                Console.WriteLine(result.Text);
            }

            Console.WriteLine();
        }
    }
}
