using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Utilities.ExtensionMethod;
using Utilities.Utilities;

namespace Utilities.Jwt
{
    public static class Jwt
    {
        private static string Issuer = Environment.GetEnvironmentVariable(ConstantsConfig.JwtIssuer).ValidateValue();
        private static string Audience = Environment.GetEnvironmentVariable(ConstantsConfig.JwtAudience).ValidateValue();
        private static string Key = Environment.GetEnvironmentVariable(ConstantsConfig.JwtKey).ValidateValue();
        private static string Expire = Environment.GetEnvironmentVariable(ConstantsConfig.JwtExpire).ValidateValue();

        public static string GenerateToken(string userName)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: new[] { new Claim("name", userName) },
                expires: DateTime.UtcNow.AddMinutes(double.Parse(Expire)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
