using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interface
{
    public interface IUserInteractions
    {
        Task<User> GetById(string Email);
        Task<User> GetByName(string Email);

        Task Add(User user);
    }
}
