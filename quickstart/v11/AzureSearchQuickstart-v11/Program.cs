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
using Aspose.Words;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
namespace AzureSearch.Quickstart


{
    class Program
    {
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
            public string key { get; set; }
            public string value { get; set; }
            public string text { get; set; }
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
        private static void UploadDocuments(SearchClient searchClient)
        {
            var myDictor = Files(@"J:\\Ai");
            int it = 0;
            foreach (var info in myDictor)
            {
                foreach (var file in info.Value)
                {
                    var batch = IndexDocumentsBatch.Create(
                        IndexDocumentsAction.Upload(new Files
                        {
                            FileID = $"{it}", // Assuming Files has a property ID
                            FileName = $"{file.value}",
                            FileText = $"{file.text}",
                            FilePath = $"{file.key}"
                        })
                    );

                    // Upload the batch to the index
                    try
                    {
                        searchClient.IndexDocuments(batch);
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions if necessary
                        Console.WriteLine($"Error uploading document: {ex.Message}");
                    }
                    it++;
                }
            }




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
        }


        static Dictionary<string, Data[]> Files(String filesd)
        {
            Dictionary<string, Data[]> myDictor = new Dictionary<string, Data[]>();

            Data[] datainfo;

            String[] files = Directory.GetFileSystemEntries(filesd);
            if (files.Length > 0)
            {
                foreach (String file in files)
                {
                    try
                    {
                        if (System.IO.File.Exists(file))
                        {
                            if (Path.GetExtension(file) == ".pdf" || Path.GetExtension(file) == ".docx" || Path.GetExtension(file) == ".doc" || Path.GetExtension(file) == ".txt")
                            {
                                string pageText = "";
                                if (Path.GetExtension(file) == ".docx")
                                {
                                    using (WordprocessingDocument doc = WordprocessingDocument.Open(file, false))
                                    {
                                        var body = doc.MainDocumentPart.Document.Body;
                                        pageText = body.InnerText;
                                        //continue;
                                    }
                                }
                                
                                switch (Path.GetExtension(file))
                                {
                                    case ".txt":
                                        pageText = System.IO.File.ReadAllText(file).Replace("\n", "");
                                        Console.WriteLine(pageText);
                                        break;
                                    case ".pdf":
                                        using (PdfReader pdfReader = new PdfReader(file))
                                        {
                                            using (PdfDocument pdfDocument = new PdfDocument(pdfReader))
                                            {
                                                int numPages = pdfDocument.GetNumberOfPages();
                                                for (int pageNum = 1; pageNum <= numPages; pageNum++)
                                                {
                                                    SimpleTextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                                                    pageText += PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(pageNum), strategy);

                                                }
                                                Console.WriteLine($":{pageText}");
                                               
                                            }
                                        }
                                        break;
                                }
                                datainfo = new Data[]
                                {
                                    new Data { key = file, value = Path.GetFileName(file), text = pageText.Replace("\n", "") }
                                };
                                myDictor.Add(file, datainfo);
                                
                            }
                            var data = new Data[]
                            {
                                new Data { key = file, value = Path.GetFileName(file), text = "" }
                            };
                            myDictor.Add(file, data);
                        }
                        else
                        {
                            Dictionary<string, Data[]> subFile = Files(file);
                            foreach (var info in subFile)
                            {
                                myDictor.Add(info.Key, info.Value);
                            }
                        }
                    }
                    catch
                    {

                    }

                }
                return myDictor;
            }
            else
            {
                String[] fileOne = Directory.GetFiles(filesd);
                foreach (String file in fileOne)
                {
                    var data = new Data[]
                    {
                        new Data { key = file, value = Path.GetFileName(file), text = "" }
                    };
                    myDictor.Add(file, data);

                    Console.WriteLine(Path.GetFileName(file));
                    Console.WriteLine(Path.GetExtension(file));
                }

                return myDictor;
            }

        }


        //static string ReadPdfFile(string filePath)
        //{
        //    using (PdfReader pdfReader = new PdfReader(filePath))
        //    {
        //        using (PdfDocument pdfDocument = new PdfDocument(pdfReader))
        //        {
        //            SimpleTextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
        //            return PdfTextExtractor.GetTextFromPage(pdfDocument.GetFirstPage(), strategy);
        //        }
        //    }
        //}

        // Run queries, use WriteDocuments to print output
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
