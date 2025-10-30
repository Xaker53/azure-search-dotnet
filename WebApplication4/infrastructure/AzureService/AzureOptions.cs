using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AzureService
{
    public class AzureOptions
    {
        public string serviceName { get; set; } = string.Empty;
        public string apiKey { get; set; } = string.Empty;
        public string indexName { get; set; } = string.Empty;
    }
}
