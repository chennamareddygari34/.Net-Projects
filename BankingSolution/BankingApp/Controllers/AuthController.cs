using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private const string SecretKey = "your_secret_key_here";
        private readonly SymmetricSecurityKey _securityKey = new(Encoding.UTF8.GetBytes(SecretKey));

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "password")
            {
                var token = GenerateToken(username);
                return Ok(new { token });
            }
            else
            {
                return Unauthorized("Invalid credentials");
            }
        }

        private string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

}

