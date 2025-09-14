using Azure.Search.Documents.Models;
using Azure.Search.Documents;
using AzureSearch.Quickstart;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.Extensions.Azure;
using System.Threading.Tasks;
using HarfBuzzSharp;
using NPOI.SS.Formula.Functions;
using System.Linq;

using Timer = System.Timers.Timer;
namespace AzureSearchQuickstart_v11.Infrastructure.Search
{
    class ThreadServer
    {
        private readonly ConcurrentQueue<IndexDocumentsAction<Files>> batch = new();
        
        private AutoResetEvent AutoResetEvent { get; set; }
        SearchClient searchClient;

        private int FlushAfterCount { get; set; }

        public long BatchCount => batch.Count;
        private int Index = 0;

        public ThreadServer(SearchClient searchClient, AutoResetEvent autoResetEvent, int flushAfterCount)
        {
            this.searchClient = searchClient;
            AutoResetEvent = autoResetEvent;
            FlushAfterCount = flushAfterCount;
        }

        public void Add(IndexDocumentsAction<Files> elem)
        {
            //elem.Document.FileID = $"{Index}";
            batch.Enqueue(elem);
            if (batch.Count > FlushAfterCount)
            {
                AutoResetEvent.Set();
            }
            //Index++;
        }

        public IEnumerable<IndexDocumentsAction<Files>> FlushBuffer()
        {
            var count = batch.Count;
            
            for (var i = 0; i < count; i++)
            {
                if (batch.TryDequeue(out var element))
                {
                    yield return element;
                }
                else
                {
                    // no more elements left
                    yield break;
                }
            }
        }


        public void StartFlushSignals(TimeSpan flushAfter)
        {
            var timer = new Timer(flushAfter);
            timer.AutoReset = true;
            // Signal the waiting thread that it's time to flush the buffer
            timer.Elapsed += (sender, e) => AutoResetEvent.Set();
            timer.Start();
        }

        public async Task UploadToAzureSearch(AutoResetEvent uploadedToAzureSearch)
        {
            uploadedToAzureSearch.Reset();
            if (batch.Count>0)
            {
                await searchClient.IndexDocumentsAsync(IndexDocumentsBatch.Create(FlushBuffer().Take(FlushAfterCount).ToArray()));
            }
            if (batch.Count <=0)
            {
                uploadedToAzureSearch.Set();
            }
            

        }

    }
}
