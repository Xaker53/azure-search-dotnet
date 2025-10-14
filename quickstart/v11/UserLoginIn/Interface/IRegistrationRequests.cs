using Core.Entities.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginIn.Interface
{
    public interface IRegistrationRequests
    {
        public Task<HttpResponseMessage> RegisterUser(UserRequest user);
    }
}
