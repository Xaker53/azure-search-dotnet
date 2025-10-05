
using Application.Interface.Auth;

namespace Infrastructure
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password, string salt) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword((password + salt));

        public bool Verify(string password, string HashedPassword) => BCrypt.Net.BCrypt.EnhancedVerify(password, HashedPassword);

    }

}
