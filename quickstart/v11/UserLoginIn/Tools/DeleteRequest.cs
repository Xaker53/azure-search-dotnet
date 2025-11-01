using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Microsoft.Extensions.Options;
using UserLoginIn.Interface;

namespace UserLoginIn.Tools
{
    sealed class DeleteRequest: IDeleteRequest
    {
        private readonly string _url;
        private HttpResponseMessage response;
        private readonly ITryDelete _tryDelete;
        public DeleteRequest(IOptions<ApiSettings> apiSettings, ITryDelete tryDelete )
        {
            _url = apiSettings.Value.DeleteUserUrl;
            _tryDelete = tryDelete;
        }

        public async Task<HttpResponseMessage> TryCatch(string UserEmail, string JwtToken = "")
        {
            return await _tryDelete.DeleteRequest(UserEmail, JwtToken, _url);
        }
    }
}
