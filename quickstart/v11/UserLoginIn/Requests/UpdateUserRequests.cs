using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using UserLoginIn.Interface;

namespace UserLoginIn.Requests
{
    sealed class UpdateUserRequests: IUpdateUserRequests
    {
        private readonly string _url;
        private readonly ITryCatchRequest _tryCatchRequest;
        public UpdateUserRequests(IOptions<ApiSettings> apiSettings, ITryCatchRequest tryCatch)
        {
            _url = apiSettings.Value.UpdateUserUrl;
            _tryCatchRequest = tryCatch;
        }

        public async Task<HttpResponseMessage> FetchToServer<T>(T UserUpdate, string JwtTokenIn)
        {
            return await _tryCatchRequest.TryCatch(_url, UserUpdate, JwtToken: JwtTokenIn);
        }
    }
}
