﻿using GarmentShop.Application.Common.Interfaces.Auth;
using GarmentShop.Application.Common.Services;
using GarmentShop.Infrastructure.Auth;
using GarmentShop.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using GarmentShop.Application.Common.Interfaces.Persistance;
using GarmentShop.Infrastructure.Persistance;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;

namespace GarmentShop.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services
                .AddAuth(configuration)
                .AddPersistance(configuration);

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }

        public static IServiceCollection AddPersistance( 
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

            return services;
        }

        public static IServiceCollection AddAuth(
           this IServiceCollection services,
           ConfigurationManager configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => 
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience= true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSettings.Secret))
                    });

            return services;
        } 
    }
}
