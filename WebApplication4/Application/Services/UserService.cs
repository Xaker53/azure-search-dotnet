using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.Interface.Auth;
using Core.Interfaces;
using Application.Services.Interface;
using Application.Services.GeneratePasswordSalt;


namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly ISaltAndHashFactory _passwordHasher;
        private readonly IRead GetByIntfo;
        private readonly IJwtProvider _jwtProvider;
        private readonly IPasswordVerify passwordVerify;
        public UserService (ISaltAndHashFactory hasher, IRead GetByUserGmail, IJwtProvider jwtProvider, IPasswordVerify passwordVerify)
        {
            this._passwordHasher = hasher;
            this.GetByIntfo = GetByUserGmail;
            this._jwtProvider = jwtProvider;
            this.passwordVerify = passwordVerify;
        }
        public async Task<string> Register(string email, string password, string salt)
        {
            return _passwordHasher.GetStrategy<PasswordHasher>().Generate(password, salt);
        }

        public async Task<string> Login (string email, string password)
        {
            var user = await GetByIntfo.GetByGmail(email);
            if (user != null)
            {
                var resuld = passwordVerify.Verify(password + user.Salt, user.Password);

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
