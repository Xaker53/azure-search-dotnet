using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginIn.Interface
{
    internal interface ITryCatchRequest
    {
        public Task<HttpResponseMessage> TryCatch<T>(string url, T user, string ContentType = "application/json", string JwtToken = "");
    }
}
