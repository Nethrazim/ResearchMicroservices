using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SO.DataLayer.Identity.Model;
using SO.BusinessLayer.Tokens;

namespace SO.BusinessLayer.Identity.Helpers
{
    internal class TokenHelper
    {
        public static Token Generate(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("asdasdasdadsadasdsaasdasdsadasasdasd");
            var claims = new Dictionary<string, object>();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("userId", user.SystemUserId.ToString()),
                            new Claim(ClaimTypes.Role, user.Role) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = "protv",
                Issuer = "protv",

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            Token response = new Token()
            {
                TokenValue = tokenHandler.WriteToken(token),
                Expires = ((DateTimeOffset)tokenDescriptor.Expires).ToUnixTimeSeconds(),
                Username = user.Username,
                Email = user.Email
            };

            return response;
        }
    }
}
