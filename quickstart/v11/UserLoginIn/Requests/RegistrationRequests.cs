
using Core.Entities.MappingProfiles;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using UserLoginIn.Interface;
using UserLoginIn.Tools;

namespace UserLoginIn.Requests
{
    internal class RegistrationRequests : IRegistrationRequests
    {
        private readonly string RegistrationUrl;
        private readonly ITryCatchRequest _tryCatchRequest;

        public RegistrationRequests(ITryCatchRequest tryCatchRequest, IOptions<ApiSettings> apiSettings)
        {
            this.RegistrationUrl = apiSettings.Value.CreateUserUrl;
            this._tryCatchRequest = tryCatchRequest;
        }

        public async Task<HttpResponseMessage> RegisterUser(UserRequest user)
        {
            return await _tryCatchRequest.TryCatch(RegistrationUrl, user);
        }
    }
}
