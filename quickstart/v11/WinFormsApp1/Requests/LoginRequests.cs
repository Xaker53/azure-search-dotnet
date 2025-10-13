using Azure;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Interface;
using WinFormsApp1.Tools;

namespace WinFormsApp1.Requests
{
    internal class LoginRequests : ILoginRequests
    {
        private readonly string _url;
        private ITryCatchRequest _tryCatchRequest;

        public LoginRequests(string url = "https://localhost:7156/api/Login")
        {
            this._url = url;
        }

        public async Task<HttpResponseMessage> LoginUser(UserLogin user)
        {
            _tryCatchRequest = new TryCatchRequest();
            return await _tryCatchRequest.TryCatch(_url, user);
        }
    }
}
