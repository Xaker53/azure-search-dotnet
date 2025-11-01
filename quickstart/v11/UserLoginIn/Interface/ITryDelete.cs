using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginIn.Interface
{
    public interface ITryDelete
    {
        public Task<HttpResponseMessage> DeleteRequest(string UserEmail, string JwtToken = "", string _url = "");
    }
}
