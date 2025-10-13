using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Interface
{
    internal interface ITryCatchRequest
    {
        public Task<HttpResponseMessage> TryCatch(string url, object user);
    }
}
