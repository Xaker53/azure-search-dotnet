namespace Application.Interface
{
    public interface IUserService
    {
        public Task<string> Register(string email, string password, string salt);
        public Task<string> Login(string email, string password);
    }
}