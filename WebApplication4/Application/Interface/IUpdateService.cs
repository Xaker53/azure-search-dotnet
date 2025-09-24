using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Application.Interface
{
    public interface IUpdateService
    {
        public Task<User> UpdateUser(UserDTO NewChanges);
    }
}
