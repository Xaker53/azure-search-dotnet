using Application.Interface;
using Application.Interface.Auth;
using Application.Services;
using Application.Services.GeneratePasswordSalt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class GenerateSaltAndHash : IGenerateSaltAndHash
    {

        private readonly ISaltAndHashFactory _hasherAndSalt;

        private string Salt;
        private string Hash;
        public string ReturnSalt => Salt;
        public string ReturnHash => Hash;

        public GenerateSaltAndHash(ISaltAndHashFactory hasher)
        {
            this._hasherAndSalt = hasher;
        }

        public void Generate(string password)
        {
            Salt = _hasherAndSalt.GetStrategy<CreateSalt>().Generate();         //_salt.GetSalt();
            Hash = _hasherAndSalt.GetStrategy<PasswordHasher>().Generate(password, Salt); //_hasher.Generate(password, Salt);
        }
    }
}
