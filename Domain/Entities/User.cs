namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }

        public User()
        {
            Username = string.Empty;
            Password = string.Empty;
        }

        public User(string username, string? email, string password)
        {
            Id = Guid.NewGuid();
            Username = username;
            Email = email;
            Password = password;
        }
    }
}
