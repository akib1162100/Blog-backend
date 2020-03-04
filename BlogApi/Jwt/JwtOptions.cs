using BlogApi.Data.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Jwt
{
    public class JwtOptions
    {
        private readonly IOptions<JwtCredentials> _jwtCredentials;

        public JwtOptions(IOptions<JwtCredentials> jwtCredentials)
        {
            this._jwtCredentials = jwtCredentials;
        }
        public string GetToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtCredentials.Value.Key));
            var claims = new List<Claim> { new Claim(ClaimTypes.Sid, user.UserID), new Claim("Cefalo", "akib")};
            var securityToken = new JwtSecurityToken(
                issuer: _jwtCredentials.Value.ValidIssuer,
                audience: _jwtCredentials.Value.ValidAudience,
                expires: DateTime.UtcNow.AddHours(_jwtCredentials.Value.Expires),
                claims: claims,
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            );
            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
    }
}
