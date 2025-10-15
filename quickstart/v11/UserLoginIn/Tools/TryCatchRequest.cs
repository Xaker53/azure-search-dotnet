using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLoginIn.Interface;
using UserLoginIn.Tools;

namespace UserLoginIn.Tools
{
    internal class TryCatchRequest : ITryCatchRequest
    {

        private IJsonconver _jsonconver;

        public TryCatchRequest(IJsonconver jsonconver)
        {
            this._jsonconver = jsonconver;
        }

        private HttpResponseMessage response;
        public async Task<HttpResponseMessage> TryCatch(string url, object user, string ContentType = "application/json")
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    response = await httpClient.PostAsync(url, _jsonconver.Jsonconver(user, ContentType));
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
