using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLoginIn.Interface;

namespace UserLoginIn.Requests
{
    internal class SearchRequests : ISearchRequests
    {
        private readonly string _url;
        private readonly ITryCatchRequest _tryCatchRequest;

        private string jsonResponse { get; set; }

        public SearchRequests(IOptions<ApiSettings> apiSettings, ITryCatchRequest tryCatch)
        {
            this._url = apiSettings.Value.AzureSearchUlr;
            this._tryCatchRequest = tryCatch;
        }

        public async Task<string> FetchToServer(string TextInput)
        {
            var resultRequest =  await _tryCatchRequest.TryCatch(_url, TextInput);
            return await resultRequest.Content.ReadAsStringAsync();

        }
    }
}
