namespace Application.Interface.Auth
{
    public interface IPasswordVerify
    {
        //string Generate(string password, string salt);

        bool Verify(string password, string HashedPassword);
    }
}