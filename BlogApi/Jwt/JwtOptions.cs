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
        private readonly IOptions<JwtModel> _jwtModel;

        public JwtOptions(IOptions<JwtModel> jwtModel)
        {
            this._jwtModel = jwtModel;
        }
        public string GetToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtModel.Value.Key));
            var claims = new List<Claim> { new Claim(ClaimTypes.Sid, user.UserId), new Claim("Cefalo", "akib") };
            var securityToken = new JwtSecurityToken(
                issuer: _jwtModel.Value.ValidIssuer,
                audience: _jwtModel.Value.ValidAudience,
                expires: DateTime.UtcNow.AddHours(_jwtModel.Value.Expires),
                claims: claims,
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512)
            );
            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
    }
}
