namespace AuthService.Interfaces
{
    public interface IAuthRepository
    {
        Task<string> Login(string username, string password);
    }
}
