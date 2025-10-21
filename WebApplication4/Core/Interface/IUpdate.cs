using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface IUpdate
    {
        public Task<User> UpdateUser(string email, UserDTO NewChanges);
    }
}
