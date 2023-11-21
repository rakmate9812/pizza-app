using API.Database.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Utilities
{
    public class JwtHelper
    {
        public static string CreateTokenForUser(IConfiguration config, User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(config.GetSection("JWTSettings:Secret").Value!));

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
    }
}
