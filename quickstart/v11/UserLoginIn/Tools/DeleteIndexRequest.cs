using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using UserLoginIn.Interface;

namespace UserLoginIn.Tools
{
    sealed class DeleteIndexRequest : IDeleteIndexRequest
    {
        private readonly string _url;
        private readonly ITryDelete _tryDelete;

        public DeleteIndexRequest(IOptions<ApiSettings> UrlService, ITryDelete tryDelete)
        {
            _url = UrlService.Value.DeleeteUserIndexUrl;
            _tryDelete = tryDelete;
        }

        public async Task<HttpResponseMessage> TryCatch(string UserEmail, string JwtToken = "")
        {
             return await _tryDelete.DeleteRequest(UserEmail, JwtToken, _url);
        }
    }
}
