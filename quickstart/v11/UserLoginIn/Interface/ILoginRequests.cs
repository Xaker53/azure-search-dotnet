using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginIn.Interface
{
    public interface ILoginRequests
    {
        public Task<HttpResponseMessage> LoginUser(UserLogin user);
    }
}
