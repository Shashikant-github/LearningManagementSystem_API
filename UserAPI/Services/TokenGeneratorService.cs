using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UserAPI.Services
{
    public class TokenGeneratorService : ITokenGeneratorService
    {
        public string GenerateToken(int userId, string userName, bool userRole)
        {
            var userClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName,userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,new Guid().ToString()),
                //new Claim(ClaimTypes.Role, userRole)
            };
            var secretKeyInBytes = Encoding.UTF8.GetBytes("asaksjalkdjsjsajflsldfghgfgjkj");
            var userSymmetricSecurityKey = new SymmetricSecurityKey(secretKeyInBytes);
            var userSigningCredentials = new SigningCredentials(userSymmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var userJwtSecurityToken = new JwtSecurityToken(
                issuer: "UserAPI",
                audience: "CoursesAPI",
                signingCredentials: userSigningCredentials,
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(90)
                );
            var userJwtSecurityTokenHandler = new { token = new JwtSecurityTokenHandler().WriteToken(userJwtSecurityToken), userName = userName, userRole = (userRole == false?"Non-Admin":"Admin") };
            var jsonSerializableResult = JsonConvert.SerializeObject(userJwtSecurityTokenHandler);
            return (jsonSerializableResult);
            //return "header.payload.signature";
            //return userJwtSecurityTokenHandler;
        }
    }
}
