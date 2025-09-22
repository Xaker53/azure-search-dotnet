using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Application.Interface
{
    internal interface IDeleteUserService
    {
        public Task<bool> Delete(string Gmail);
    }
}
