namespace Application.Services.Auth
{
    public interface IAuthService
    {
        public void RegisterAccount(string username, string? email, string password);
        public string Login(string username, string password);
    }
}
