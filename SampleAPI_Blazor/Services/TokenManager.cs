using Microsoft.IdentityModel.Tokens;
using SampleAPI_Blazor.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SampleAPI_Blazor.Services
{
    public class TokenManager
    {
        public static string secret = "molidsjmoqsidjfpçuzehcmonhqàp^hzedfouchq^çàuhefoquiehc^àqiezfîoqhe^àifhqz";

        public string GenerateToken(User u) 
        { 
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            Claim[] myclaims = new Claim[]
            {
                new Claim(ClaimTypes.Role, u.IsAdmin ? "Admin": "User"),
                new Claim("Username", u.UserName),
                new Claim(ClaimTypes.Email, u.Email)
            };

            JwtSecurityToken token = new JwtSecurityToken(
                claims: myclaims,
                signingCredentials: credentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }

    }
}
