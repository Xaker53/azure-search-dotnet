using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Interface.Auth;
using Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure
{
    public class JwtProvider: IJwtProvider
    {
        private readonly JwtOptions _jwtOptions;
        public JwtProvider (IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;
        }


        public string GenerateToken(User user)
        {
            Claim[] claims = [new ("userId", user.UserId.ToString())];

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddDays(_jwtOptions.ExpiresHours));

            var TokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return TokenValue;
        }
    }
}
