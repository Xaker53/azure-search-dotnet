using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginIn.Interface
{
    public interface IDeleteUserRequests
    {
        public Task<HttpResponseMessage> FetchToServer(string UserUpdate, string JwtTokenIn);
    }
}
