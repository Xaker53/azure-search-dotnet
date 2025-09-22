using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IDelete
    {
        public Task<bool> DeleteUser(string email);
    }
}
