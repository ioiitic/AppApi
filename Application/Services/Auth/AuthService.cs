using Infrastructure.Repos.Auth;

namespace Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private IAuthRepo _authRepo;

        public AuthService(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }

        public void RegisterAccount(string username, string? email, string password)
        {
            /// Check trung username hoac email
            /// Tim trong DB -> user hoac email
            bool exist = _authRepo.CheckUser(username, email);
            if (exist)
            {
                throw new Exception("Exist");
            }
            _authRepo.RegisterAccount(username, email, password);
        }

        public bool Login(string username, string password)
        {
            return _authRepo.Login(username, password);
        }
    }
}
