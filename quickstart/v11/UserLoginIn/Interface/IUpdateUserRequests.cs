using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginIn.Interface
{
    public interface IUpdateUserRequests
    {
        public Task<HttpResponseMessage> FetchToServer<T>(T UserUpdate, string JwtTokenIn);
    }
}
