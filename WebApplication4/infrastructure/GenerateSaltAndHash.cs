using Application.Interface;
using Application.Interface.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class GenerateSaltAndHash : IGenerateSaltAndHash
    {

        private readonly IPasswordHasher _hasher;
        private readonly ISalt _salt;

        private string Salt;
        private string Hash;
        public string ReturnSalt => Salt;
        public string ReturnHash => Hash;

        public GenerateSaltAndHash(IPasswordHasher hasher, ISalt salt)
        {
            this._hasher = hasher;
            this._salt = salt;
        }

        public void Generate(string password)
        {
            Salt = _salt.GetSalt();
            Hash = _hasher.Generate(password, Salt);
        }
    }
}
