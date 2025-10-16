using Azure;
using Core.Entities.MappingProfiles;
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
    internal class GetUserRequests : IGetUserRequests
    {
        private readonly string _url;

        public GetUserRequests(IOptions<ApiSettings> apiSettings)
        {
            this._url = apiSettings.Value.AzureGetUser;
        }

        public async Task<HttpResponseMessage> FetchToServer(string UserGmail, string JwtToken = "")
        {
            if (UserGmail == null) return null;
            using (HttpClient httpClient = new())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", $"{JwtToken}");
                    var response = await httpClient.GetAsync($"https://localhost:7156/api/GetEmail/?email={UserGmail}");

                    return response;
                }
                catch (HttpRequestException ex)
                {
                    throw new HttpRequestException("Error while requesting server", ex);
                }

            }
        }
    }
}
