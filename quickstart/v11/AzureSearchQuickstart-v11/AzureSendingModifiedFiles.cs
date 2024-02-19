using Azure.Search.Documents.Models;
using Azure.Search.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.IO;
using Org.BouncyCastle.Crypto.Agreement.Srp;

namespace AzureSearch.Quickstart
{
    interface ISendFiles
    {
        void SendingInformation();
    }


    public class AzureSendingModifiedFiles: ManagementAzure, ISendFiles
    {
        private SearchOptions options;
        private SearchResults<Files> response;
        private string function;
        private string path { get; set; }
        private string NewPath;
        private string NewName;
        private Files NewDocument { get; set; }
        private List<Files> resultSearch { get; set; }
        private bool Answer = false;

        public Files AmendedDocument => NewDocument;

        public bool GetAnswer => Answer;
        public string GetPath => path;

        public AzureSendingModifiedFiles() 
        {
            Start();
        }
        public void ConnectSearchFiles(string request)
        {
            options = new SearchOptions();
            this.path = Path.GetFullPath(request);
            options.Filter = SearchFilter.Create(FormattableStringFactory.Create($"{nameof(Files.FilePath)} eq '{path}'"));
            this.response = srchclient.Search<Files>($"*", options);
            GetResult();
        }

        private void GetResult()
        {
            if (response.GetResults().FirstOrDefault() != null)
            {
                Answer = true;
                this.resultSearch = new List<Files>();
                NewDocument = (response.GetResults().FirstOrDefault().Document);
            }
            else { Answer = false; }
        }

        public void SendingInformation()
        {
            resultSearch.Add(NewDocument);
            var indexActions = this.resultSearch.Select(file => IndexDocumentsAction.Upload(file));
            ingesterClient.IndexDocuments(IndexDocumentsBatch.Create(indexActions.ToArray()));
        }
    }
}
