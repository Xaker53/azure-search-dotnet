using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using UserLoginIn.Interface;

namespace UserLoginIn.Tools
{
    sealed class TryDelete : ITryDelete
    {
        private HttpResponseMessage response;
        public async Task<HttpResponseMessage> DeleteRequest (string UserEmail, string JwtToken = "", string _url = "")
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
