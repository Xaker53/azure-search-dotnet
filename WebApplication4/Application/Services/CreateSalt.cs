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
        private readonly string _salt;
        public CreateSalt()
        {
            this._salt = Convert.ToBase64String(RandomNumberGenerator.GetBytes(128 / 8));
        }
        public string GetSalt()
        {
            return _salt;
        }
    }
}
