using Domain.Entities;
using Infrastructure.Repos.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        public string Login(string username, string password)
        {
            string token = string.Empty;
            bool check = _authRepo.Login(username, password);
            if (check)
            {
                token = GenerateJwtToken(username);
            }

            return token;
        }

        private string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("a-string-secret-at-least-256-bits-long"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}