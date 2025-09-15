using System;
using System.Text.Json.Serialization;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;

namespace AzureSearch.Quickstart
{
    public partial class Files
    {
        [SimpleField(IsKey = true, IsFilterable = true)]
        public string FileID { get; set; }

        [SearchableField(IsSortable = true)]
        public string IndexerName { get; set; }

        [SearchableField(IsSortable = true)]
        public string FileName { get; set; }

        [SearchableField (IsSortable = true)]
        public string FileText { get; set; }

        [SearchableField(IsSortable = true)]
        public string FileRecoveryText { get; set; }

        [SearchableField(IsFilterable = true)]
        public string FilePath { get; set; }

    }
}
