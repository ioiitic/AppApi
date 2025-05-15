using Domain.Entities;

namespace Infrastructure.Repos.Auth
{
    public class AuthRepo : IAuthRepo
    {
        private ICollection<User> _users;
        
        public AuthRepo()
        {
            _users = [];
        }

        public void RegisterAccount(string username, string? email, string password)
        {
            User user = new(username, email, password);
            _users.Add(user);
        }

        public bool Login(string username, string password)
        {
            return _users.Any(x => x.Username == username && x.Password == password);
        }

        public bool CheckUser(string username, string? email)
        {
            bool check = _users.Any(x => x.Username == username);
            if (email != null)
            {
                check |= _users.Any(x => x.Email == email);
            }

            return check;
        }
    }
}
