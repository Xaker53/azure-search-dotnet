
using Application.Interface.Auth;

namespace Infrastructure
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool Verify(string password, string HashedPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, HashedPassword);
        }
    }

}
