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
using Microsoft.Extensions.Azure;
namespace AzureSearch.Quickstart
{
    interface ISendFiles
    {
        void SendingInformation();
        void ConnectSearchFiles(string request);
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
        private Queue<Files> resultSearch  = new Queue<Files>();
        private bool Answer = false;
        public int LastIndex = 0;

        public Files AmendedDocument => NewDocument;

        public bool GetAnswer => Answer;
        public string GetPath => path;
        public string LastIndexDocument => (LastIndex + 1).ToString();

        public AzureSendingModifiedFiles() 
        {
            Start();
            NewDocument = new AzureSearch.Quickstart.Files();
            GetLastIndex();
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
                NewDocument = (response.GetResults().FirstOrDefault().Document);
            }
            else { Answer = false; }
        }

        public void SendingInformation()
        {
            resultSearch.Enqueue(NewDocument);
            //var indexActions = this.resultSearch .Select(file => IndexDocumentsAction.Upload(file));
            ingesterClient.IndexDocuments(IndexDocumentsBatch.Create(BufferQueue().ToArray()));
            GetLastIndex();
        }

        private IEnumerable <IndexDocumentsAction<Files>> BufferQueue()
        {
            if (resultSearch.TryDequeue(out var element))
            {
                yield return IndexDocumentsAction.Upload(element);
            }
        }

        private void GetLastIndex()
        {
            LastIndex = (int)srchclient.GetDocumentCount().Value;
        }
    }
}
