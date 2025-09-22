using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Core.Interfaces;

namespace Application.Services
{
    public class UserDeleteService (IDelete userDelete) : IDeleteUserService
    {
        public Task<bool> Delete(string Gmail)
        {
            return userDelete.DeleteUser(Gmail);
        }
    }
}
