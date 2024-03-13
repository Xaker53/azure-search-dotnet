using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Microsoft.Extensions.Options;
using System.IO;
using System.Runtime.CompilerServices;
using Azure.Search.Documents.Models;
using AzureSearch.Quickstart;


namespace WebApplication4
{
    public class ConnectAzure
    {
        private string serviceName = "search53";
        private string apiKey = "FVSYI2BfI4x26m6LDy55Ix4vaQqxvKlX7SKCxtmJf2AzSeCxpQRV";
        private string indexName = "hquickstart";
        private Uri serviceEndpoint;
        private AzureKeyCredential credential;
        private SearchIndexClient adminClient;
        protected SearchClient srchclient;
        protected SearchClient ingesterClient;
        private SearchOptions options;
        


        public ConnectAzure()
        {
            serviceEndpoint = new Uri($"https://{serviceName}.search.windows.net/");
            credential = new AzureKeyCredential(apiKey);
            adminClient = new SearchIndexClient(serviceEndpoint, credential);
            srchclient = new SearchClient(serviceEndpoint, indexName, credential);// Create a SearchClient to load and query documents
            ingesterClient = adminClient.GetSearchClient(indexName);
        }

        public List<Files> ConnectSearchFiles(string request)
        {
            options = new SearchOptions()
            {
                
                QueryType = SearchQueryType.Full
            };
            options.Select.Add("FileID");
            options.Select.Add("FileName");
            options.Select.Add("FileText");
            options.Select.Add("FilePath");
            SearchResults<Files> test = srchclient.Search<Files>($"{request}~", options);

            List<Files> list = new();

            foreach (SearchResult<Files> file in test.GetResults())
            {
                list.Add(file.Document);
            }

            return list;
        }
    }
}
