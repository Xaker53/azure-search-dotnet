using Azure.Search.Documents.Indexes;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Search.Documents;
using NPOI.HSSF.Record.Chart;
using Azure.Search.Documents.Indexes.Models;
using AzureSearch.Quickstart;
using Azure.Search.Documents.Models;
using System.IO;
using System.Runtime.CompilerServices;
using AzureSearchQuickstart_v11;

namespace AzureSearch.Quickstart
{
    public class ManagementAzure
    {
        private string serviceName = "search53";
        private string apiKey = "FVSYI2BfI4x26m6LDy55Ix4vaQqxvKlX7SKCxtmJf2AzSeCxpQRV";
        private string indexName = "hquickstart";

        private Uri serviceEndpoint;
        private AzureKeyCredential credential;
        private SearchIndexClient adminClient;
        protected SearchClient srchclient;
        protected SearchClient ingesterClient;

        public SearchClient Srchclient => srchclient;
        public SearchIndexClient AdminClient => adminClient;
        public string IndexName => indexName;

        public SearchClient IngesterClient => ingesterClient;

        private List<Files> resultSearch;


        private static ThreadServer buffer;

        public ManagementAzure()
        {

        }


        // Create a SearchIndexClient to send create/delete index commands
        public void Start()
        {
            serviceEndpoint = new Uri($"https://{serviceName}.search.windows.net/");
            credential = new AzureKeyCredential(apiKey);
            adminClient = new SearchIndexClient(serviceEndpoint, credential);
            srchclient = new SearchClient(serviceEndpoint, indexName, credential);// Create a SearchClient to load and query documents
            ingesterClient = adminClient.GetSearchClient(indexName);
        }


        public void DeleteIndexIfExists()
        {
            adminClient.GetIndexNames();
            
            adminClient.DeleteIndex(indexName);
            
        }

        public void CreateIndex()
        {
            FieldBuilder fieldBuilder = new FieldBuilder();
            var searchFields = fieldBuilder.Build(typeof(Files));

            var definition = new SearchIndex(indexName, searchFields);


            var suggester = new SearchSuggester("sg", new[] { "FileText" });


            definition.Suggesters.Add(suggester);

            adminClient.CreateOrUpdateIndex(definition);
        }

        //public void RunQueries(string request, string function, string NewPath = "", string NewName = "", string PathFile = "")
        //{
        //    SearchOptions options;
        //    SearchResults<Files> response;
            

        //    options = new SearchOptions();
        //    var path = Path.GetFullPath(request);
        //    options.Filter = SearchFilter.Create(FormattableStringFactory.Create($"{nameof(Files.FilePath)} eq '{path}'"));
        //    //options.Select.Add("FileID");
        //    //options.Select.Add("FileName");
        //    //options.Select.Add("FileText");
        //    //options.Select.Add("FilePath");
        //    response = srchclient.Search<Files>($"*", options);
        //    var Fortest = response.GetResults().FirstOrDefault();
        //    if (response.GetResults().FirstOrDefault() != null)
        //    {
        //        var test = response.GetResults().FirstOrDefault().Document;
        //        switch (function)
        //        {
        //            case "Renamed":
        //                this.resultSearch = new List<Files>();
        //                test.FileName = $"{NewName}";
        //                test.FilePath = Path.GetFullPath(NewPath);
        //                this.resultSearch.Add(test);
        //                SendRequest();
        //                break;
        //            case "Changer":
        //                if (IsSupportedExtension(Path.GetExtension(path)))
        //                {
        //                    if (path == Path.GetFullPath(test.FilePath))
        //                    {
        //                        AzureSearchQuickstart_v11.GetFileText getFileText = new(path, Path.GetExtension(path));
        //                        this.resultSearch = new List<Files>();

        //                        test.FileText = getFileText.getPageText();
        //                        this.resultSearch.Add(test);
        //                        SendRequest();
        //                    }
        //                    //else if ()
        //                    //else if (Path.GetFullPath(PathFile) != Path.GetFullPath(test.FilePath))
        //                    //{
        //                    //    test.FilePath = PathFile;
        //                    //    this.resultSearch.Add(test);
        //                    //    SendRequest();
        //                    //}
                            
        //                }
        //                break;
        //            case "Deleted":
        //                this.resultSearch = new List<Files>();
        //                this.resultSearch.Add(response.GetResults().FirstOrDefault().Document);
        //                var indexActions = this.resultSearch.Select(file => IndexDocumentsAction.Upload(file));
        //                ingesterClient.IndexDocuments(IndexDocumentsBatch.Delete(indexActions));
        //                break;

        //        }
        //    }
        //    //else if (response.GetResults().FirstOrDefault() == null && function == "Changer")
        //    //{
        //    //    if (IsSupportedExtension(Path.GetExtension(path)))
        //    //    {
        //    //        var test = new Files();
        //    //        AzureSearchQuickstart_v11.GetFileText getFileText = new(path, Path.GetExtension(path));
        //    //        this.resultSearch = new List<Files>();
        //    //        test.FileText = getFileText.getPageText();
        //    //        test.FileName = Path.GetFileName(path);
        //    //        test.FileID = (IngesterClient.GetDocumentCount().Value + 1).ToString();
        //    //        test.FilePath = path;
        //    //        this.resultSearch.Add(test);
        //    //        SendRequest();
        //    //    }
        //    //}


        //    //if (response.GetResults().FirstOrDefault() != null)
        //    //{
        //    //    this.resultSearch = new List<Files>();
        //    //    var test = response.GetResults().FirstOrDefault().Document;
        //    //    test.FileText = "test";
        //    //    this.resultSearch.Add(test);

        //    //    var indexActions = this.resultSearch.Select(file => IndexDocumentsAction.Upload(file));

        //    //    ingesterClient.IndexDocuments(IndexDocumentsBatch.Create(indexActions.ToArray()));
        //    //}


        //}

        //private void SendRequest()
        //{
        //    var indexActions = this.resultSearch.Select(file => IndexDocumentsAction.Upload(file));
        //    ingesterClient.IndexDocuments(IndexDocumentsBatch.Create(indexActions.ToArray()));
        //}

        //private bool IsSupportedExtension(string extension)
        //{
        //    string[] supportedExtensions = { ".pdf", ".docx", ".doc", ".txt" };

        //    return supportedExtensions.Contains(extension);
        //}
    }
}
