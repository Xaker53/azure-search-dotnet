namespace Application.Interface.Auth
{
    public interface IPasswordHasher
    {
        string Generate(string password, string salt);

        bool Verify(string password, string HashedPassword);
    }
}