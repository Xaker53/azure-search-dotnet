using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.Interface.Auth;

namespace Application.Services.GeneratePasswordSalt
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password, string salt) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password + salt);
    }
}
