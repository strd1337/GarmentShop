using GarmentShop.Application.Common.Interfaces.Auth;
using GarmentShop.Application.Common.Services;
using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.UserAggregate.Enums;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GarmentShop.Infrastructure.Auth
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly JwtSettings jwtSettings;

        public JwtTokenGenerator(
            IDateTimeProvider dateTimeProvider,
            IOptions<JwtSettings> jwtOptions)
        {
            this.dateTimeProvider = dateTimeProvider;
            this.jwtSettings = jwtOptions.Value;
        }

        public string GenerateToken(Authentication user) 
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()!),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, 
                    Enum.GetName(typeof(RoleType), RoleType.Customer)!)
            };

            var securityToken = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                expires: dateTimeProvider.UtcNow.AddMinutes(jwtSettings.ExpiryMinutes),
                claims: claims,
                signingCredentials: signingCredentials); 

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
