using API.Database.DTOs;
using API.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace API.Controllers
{
    //TODO - create a user repository for the methods, and refactor a bit
    [Route("auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] UserDto request)
        {
            if (ModelState.IsValid)
            {
                // check if the username exists
                CreatePasswordHash(request.Password, out byte[] hash, out byte[] salt);
                var user = new User();
                user.Username = request.Username;
                user.PasswordHash = hash;
                user.PasswordSalt = salt;

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(user);
            }

            return BadRequest("Invalid User data");
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] UserDto request)
        {
            var user = _context.Users.Where(u => string.Equals(u.Username, request.Username)).FirstOrDefault();

            if (user == null)
            {
                return NotFound("User not found with the given username");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password");
            }

            return Ok(CreateToken(user));
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("JWTSettings:Secret").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                issuer: "https://id.rakmate9812.com",
                audience: "https://pizza-app.rakmate9812.com",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
        {
            using (var hmac = new HMACSHA512())
            {

                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] hash, byte[] salt)
        {
            using (var hmac = new HMACSHA512(salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(hash);
            }
        }
    }
}
