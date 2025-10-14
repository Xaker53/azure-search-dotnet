using Core.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLoginIn.Interface;
using UserLoginIn.Tools;

namespace UserLoginIn.Requests
{
    internal class LoginRequests : ILoginRequests
    {
        private readonly string _url;
        private readonly ITryCatchRequest _tryCatchRequest;

        public LoginRequests(IOptions<ApiSettings> apiSettings, ITryCatchRequest tryCatch)
        {
            this._url = apiSettings.Value.LoginUserUrl;
            this._tryCatchRequest = tryCatch;
        }

        public async Task<HttpResponseMessage> LoginUser(UserLogin user)
        {
            return await _tryCatchRequest.TryCatch(_url, user);
        }
    }
}
