using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginIn.Interface
{
    public interface IGetUserRequests
    {
        public Task<HttpResponseMessage> FetchToServer(string UserGmail, string JwtToken = "");
    }
}
