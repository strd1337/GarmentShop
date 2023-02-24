using GarmentShop.Application.Common.Interfaces.Auth;
using GarmentShop.Application.Common.Services;
using GarmentShop.Infrastructure.Auth;
using GarmentShop.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Infrastructure.Persistance.Repositories.Common;
using GarmentShop.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using GarmentShop.Infrastructure.Auth.Permissions;
using GarmentShop.Infrastructure.Auth.Roles;
using GarmentShop.Domain.Common.Models;
using GarmentShop.Domain.UserAggregate;
using GarmentShop.Domain.UserAggregate.ValueObjects;
using GarmentShop.Infrastructure.Persistance.Repositories.UserAgg;
using GarmentShop.Domain.UserAggregate.Entities;
using Quartz;
using GarmentShop.Infrastructure.BackgroundJobs;
using MediatR;
using GarmentShop.Infrastructure.Idempotence;

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
                .AddDbContext(configuration)
                .AddQuartz()
                .AddPersistance();

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.Decorate(
                typeof(INotificationHandler<>), 
                typeof(IdempotentDomainEventHandler<>));

            return services;
        }

        public static IServiceCollection AddDbContext(
           this IServiceCollection services,
           ConfigurationManager configuration)
        {
            services.AddDbContext<GarmentShopDbContext>((sp, options) =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
        
        public static IServiceCollection AddQuartz(
            this IServiceCollection services)
        {
            services.AddQuartz(configure =>
            {
                var jobKey = new JobKey(nameof(ProcessOutboxMessageesJob));

                configure
                    .AddJob<ProcessOutboxMessageesJob>(jobKey)
                    .AddTrigger(trigger =>
                        trigger.ForJob(jobKey)
                            .WithSimpleSchedule(schedule =>
                                schedule.WithIntervalInSeconds(10)
                                    .RepeatForever()));

                configure.UseMicrosoftDependencyInjectionJobFactory();
            });

            services.AddQuartzHostedService();

            return services;
        }

        public static IServiceCollection AddPersistance( 
            this IServiceCollection services)
        {
            services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddCustomRepository<User, UserId, UserRepository>()
                .AddCustomRepository<Role, RoleId, RoleRepository>();

            return services;
        }

        public static IServiceCollection AddCustomRepository<TEntity, TId, TRepository>(
            this IServiceCollection services)
               where TEntity : Entity<TId>
               where TId : ValueObject
               where TRepository : class, IGenericRepository<TEntity, TId>
            
        {
            services.AddScoped<IGenericRepository<TEntity, TId>, TRepository>();

            return services;
        }

        public static IServiceCollection AddAuth(
           this IServiceCollection services,
           ConfigurationManager configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
            services.AddSingleton<IAuthorizationHandler, RoleAuthorizationHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, RoleAuthorizationPolicyProvider>();

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
