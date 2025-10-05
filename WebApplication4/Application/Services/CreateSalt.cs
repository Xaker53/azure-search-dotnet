using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;

namespace Application.Services
{
    public class CreateSalt : ISalt
    {
        public string GetSalt()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(128 / 8));
        }
    }
}
