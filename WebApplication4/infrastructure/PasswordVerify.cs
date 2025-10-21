
using Application.Interface.Auth;
using Infrastructure;

namespace Infrastructure
{
    public class PasswordVerify : IPasswordVerify
    {
        public string Generate(string password, string salt) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword((password + salt));

        public bool Verify(string password, string HashedPassword) => BCrypt.Net.BCrypt.EnhancedVerify(password, HashedPassword);

    }

}

