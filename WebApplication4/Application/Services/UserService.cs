using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.Interface.Auth;
using Core.Interfaces;


namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IRead GetByIntfo;
        private readonly IJwtProvider _jwtProvider;
        public UserService (IPasswordHasher hasher, IRead GetByUserGmail, IJwtProvider jwtProvider)
        {
            this._passwordHasher = hasher;
            this.GetByIntfo = GetByUserGmail;
            this._jwtProvider = jwtProvider;
        }
        public async Task<string> Register(string email, string password, string salt)
        {
            return _passwordHasher.Generate(password, salt);
        }

        public async Task<string> Login (string email, string password)
        {
            var user = await GetByIntfo.GetByGmail(email);
            if (user != null)
            {
                var resuld = _passwordHasher.Verify(password + user.Salt, user.Password);

                if (resuld != true)
                {
                    throw new Exception("Fail to login");
                }
                return _jwtProvider.GenerateToken(user);

            }
            return null;
        }
    }
}
