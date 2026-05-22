using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestionITM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // ESTO <--- endpoint login
        [HttpPost("login")]
        public IActionResult Login()
        {
            // ESTO <--- claims del usuario
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "Samuel"),
                new Claim(ClaimTypes.Role, "Administrador")
            };

            // ESTO <--- llave secreta
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            // ESTO <--- credenciales
            var creds = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            // ESTO <--- crear token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            // ESTO <--- devolver token
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}