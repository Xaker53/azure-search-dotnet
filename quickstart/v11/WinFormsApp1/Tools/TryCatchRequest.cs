using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Interface;
using WinFormsApp1.Tools;

namespace WinFormsApp1.Tools
{
    internal class TryCatchRequest : ITryCatchRequest
    {

        private IJsonconver jsonconver;
        private HttpResponseMessage response;
        public async Task<HttpResponseMessage> TryCatch(string url, object user)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    jsonconver = new ConvertToJson();
                    response = await httpClient.PostAsync(url, jsonconver.Jsonconver(user));
                    return response.EnsureSuccessStatusCode();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error.");
                    return response.EnsureSuccessStatusCode();
                }
            }
        }
    }
}
