﻿using ErrorOr;
using GarmentShop.Application.Common.Interfaces.Auth;
using GarmentShop.Domain.Common.Errors;
using GarmentShop.Application.Auth.Common;
using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.UserAggregate;
using GarmentShop.Domain.UserAggregate.ValueObjects;
using GarmentShop.Domain.UserAggregate.Enums;
using GarmentShop.Application.Common.CQRS;
using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Domain.AuthenticationAggregate.ValueObjects;
using GarmentShop.Domain.UserAggregate.Entities;
using GarmentShop.Application.Common.Interfaces.Persistance.UserRepositories;
using GarmentShop.Application.Common.Interfaces.Persistance.AuthRepositories;

namespace GarmentShop.Application.Auth.Commands.Register
{
    public class RegisterCommandHandler :
        ICommandHandler<RegisterCommand, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IUnitOfWork unitOfWork;
        private readonly IAuthRepository authRepository;

        public RegisterCommandHandler(
            IJwtTokenGenerator jwtTokenGenerator, 
            IUnitOfWork unitOfWork,
            IAuthRepository authRepository)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.unitOfWork = unitOfWork;
            this.authRepository = authRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            RegisterCommand command,  
            CancellationToken cancellationToken)
        {
            if (await authRepository.IsEmailNotUniqueAsync(
                command.Email, cancellationToken))
            {
                return Errors.User.DuplicateEmail;
            }

            if (await authRepository.IsUsernameNotUniqueAsync(
                command.UserName, cancellationToken))
            {
                return Errors.User.DuplicateUsername;
            }

            var role = await unitOfWork
                 .GetRepository<Role, RoleId>()
                 .FirstOrDefaultAsync(
                    x => x.Name == RoleType.Customer.ToString(),
                    cancellationToken);

            var user = User.Create(UserDetailInformation.CreateNew());

            var userRepository = unitOfWork.GetRepository<User, UserId>(true) 
                as IUserRepository;
 
            await userRepository!.AddRoleAsync(user, role!);

            await userRepository.AddAsync(user, cancellationToken);

            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string passwordHash = BCrypt.Net.BCrypt
                .HashPassword(command.Password, salt);

            var registeringUser = Authentication.Create(
                command.UserName,
                command.Email,
                passwordHash,
                salt,
                UserId.Create(user.Id.Value));

            await unitOfWork
                .GetRepository<Authentication, AuthenticationId>()
                .AddAsync(registeringUser, cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            var token = jwtTokenGenerator.GenerateToken(registeringUser, user);

            return new AuthenticationResult(
                registeringUser.Id.Value,
                registeringUser,
                token);
        }
    }
}
