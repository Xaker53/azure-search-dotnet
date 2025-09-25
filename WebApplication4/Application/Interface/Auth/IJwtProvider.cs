using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Application.Interface.Auth
{
    public interface IJwtProvider
    {
        public string GenerateToken(User user);
    }
}
