using Core.Entities.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Interface;
using WinFormsApp1.Tools;

namespace WinFormsApp1.Requests
{
    internal class RegistrationRequests : IRegistrationRequests
    {
        private readonly string RegistrationUrl;
        private ITryCatchRequest _tryCatchRequest;

        public RegistrationRequests(string Uri = "https://localhost:7156/api/Create")
        {
            this.RegistrationUrl = Uri;
        }

        public async Task<HttpResponseMessage> RegisterUser(UserRequest user)
        {
            _tryCatchRequest = new TryCatchRequest();
            return await _tryCatchRequest.TryCatch(RegistrationUrl, user);
        }
    }
}
