using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Core.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UserLoginIn.Interface;

namespace UserLoginIn.Requests
{
    sealed class DeleteUserRequests : IDeleteUserRequests
    {
        private readonly string _url;
        private readonly IDeleteRequest _deleteUser;
        public DeleteUserRequests(IDeleteRequest deleteUser)
        {
            _deleteUser = deleteUser;
        }

        public async Task<HttpResponseMessage> FetchToServer(string UserUpdate, string JwtTokenIn)
        {
            if (!string.IsNullOrEmpty(UserUpdate))
            {
                return await _deleteUser.TryCatch(UserUpdate, JwtTokenIn);
            }
            return null;
        }
    }
}
