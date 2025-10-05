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

namespace AzureSearchQuickstart_v11.Infrastructure.Search
{
    public class ManagementAzure
    {
        private string serviceName = "search53";
        private string apiKey = "j7F5AnRIc8XTDGNfdgZ4DIiuSZCb9rbP9IMaUtfJRBAzSeBnW1QG";
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

        public bool ThereIndex()
        {
            var a = adminClient.GetSearchClient;
            if (a == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Create a SearchIndexClient to send create/delete index commands
        public void Start()
        {
            serviceEndpoint = new Uri($"https://{serviceName}.search.windows.net/");
            credential = new AzureKeyCredential(apiKey);
            adminClient = new SearchIndexClient(serviceEndpoint, credential);
            srchclient = new SearchClient(serviceEndpoint, indexName, credential);// Create a SearchClient to load and query documents
            ingesterClient = adminClient.GetSearchClient(indexName);
            CreateIndex();
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
    }
}
