using Microsoft.IdentityModel.Tokens;
using MinhasFinancas.Infra.CrossCutting.Auth.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Infra.CrossCutting.Auth.Services
{
    public static class TokenService
    {
        public static string GenerateToken(string userId, string userEmail)
        {
            var _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenSettings.TokenSecret));
            var _issuer = TokenSettings.Issuer;
            var _audience = TokenSettings.Audience;
            var signinCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: new List<Claim>
                {
                    new Claim("UserId", userId),
                    new Claim(JwtRegisteredClaimNames.Sub, userEmail),
                    new Claim(JwtRegisteredClaimNames.Email, userEmail)
                },
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: signinCredentials);

            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }
    }
}
