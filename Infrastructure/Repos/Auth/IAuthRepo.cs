namespace Infrastructure.Repos.Auth
{
    public interface IAuthRepo
    {
        public void RegisterAccount(string username, string? email, string password);
        public bool Login(string username, string password);
        public bool CheckUser(string username, string? email);
    }
}
