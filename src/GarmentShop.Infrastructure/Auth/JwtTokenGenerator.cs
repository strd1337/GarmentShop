using GarmentShop.Application.Common.Interfaces.Auth;
using GarmentShop.Application.Common.Services;
using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.UserAggregate;
using GarmentShop.Domain.UserAggregate.Entities;
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
            jwtSettings = jwtOptions.Value;
        }

        public string GenerateToken(Authentication authUser, User user) 
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, authUser.Id.Value.ToString()),
                new(JwtRegisteredClaimNames.UniqueName, authUser.UserName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var permissions = new List<Permission>();
            foreach (var userRole in user.Roles)
            {
                claims.Add(new(CustomClaims.Roles,
                    Enum.GetName(typeof(RoleType), userRole.Role.Type)!));

                permissions.AddRange(userRole.Role.Permissions);
            }

            foreach(var permission in permissions)
            {
                claims.Add(new(CustomClaims.Permissions, 
                    Enum.GetName(typeof(PermissionType), permission.Type)!));
            }
            
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);

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
