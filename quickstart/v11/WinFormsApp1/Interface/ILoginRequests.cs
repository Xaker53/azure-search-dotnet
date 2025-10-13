using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Interface
{
    internal interface ILoginRequests
    {
        public Task<HttpResponseMessage> LoginUser(UserLogin user);
    }
}
