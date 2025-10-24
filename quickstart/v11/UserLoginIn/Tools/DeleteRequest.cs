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
        public DeleteRequest(IOptions<ApiSettings> apiSettings)
        {
            _url = apiSettings.Value.DeleteUserUrl;
        }

        public async Task<HttpResponseMessage> TryCatch(string UserEmail, string JwtToken = "")
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", $"{JwtToken}");
                    response = await httpClient.DeleteAsync($"{_url}{UserEmail}");
                    return response;
                }
                catch (Exception e)
                {
                    //MessageBox.Show("Error.");
                    return response;
                }
            }
        }
    }
}
