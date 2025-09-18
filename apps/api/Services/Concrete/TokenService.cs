using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

using api.Entities;
using api.Exceptions;
using api.Services.Abstract;

namespace api.Services.Concrete
{
    public class TokenService(IConfiguration configuration) : ITokenService
    {
        public string CreateAccessToken(User user)
        {
            var secret = Environment.GetEnvironmentVariable("JWT_SECRET");
            if (string.IsNullOrEmpty(secret))
                throw new DotEnvException("JWT_SECRET");

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Username),
                new("id", user.Id.ToString()),
                new("isAdmin", user.IsAdmin.ToString())
            };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secret)
            );
            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("Jwt:Issuer"),
                audience: configuration.GetValue<string>("Jwt:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public string CreateRefreshToken()
        {
            var token = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(token);
            return Convert.ToBase64String(token);
        }
    }
}
