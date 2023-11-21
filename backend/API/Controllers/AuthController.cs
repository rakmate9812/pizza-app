using API.Database.DTOs;
using API.Database.Models;
using API.Repositories;
using API.Utilities;
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
        private readonly UserRepository _userRepository;

        public AuthController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
            _userRepository = new UserRepository(_context);

        }

        [HttpPost("register")]
        public ActionResult<User> Register([FromBody] UserDto request)
        {
            if (_userRepository.GetByUserName(request.Username) != null) return BadRequest("A user exists with the same username");

            PasswordHasher.CreatePasswordHash(request.Password, out byte[] hash, out byte[] salt);

            var user = new User()
            {
                Username = request.Username,
                PasswordHash = hash,
                PasswordSalt = salt
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] UserDto request)
        {
            var user = _userRepository.GetByUserName(request.Username);

            if (user == null) return NotFound("User not found with the given username");

            if (!PasswordHasher.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt)) return BadRequest("Wrong password");

            return Ok(JwtHelper.CreateTokenForUser(_config, user));
        }

    }
}
