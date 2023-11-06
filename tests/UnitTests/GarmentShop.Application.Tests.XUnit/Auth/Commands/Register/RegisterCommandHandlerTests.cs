using FluentAssertions;
using GarmentShop.Application.Auth.Commands.Register;
using GarmentShop.Application.Common.Interfaces.Auth;
using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Application.Common.Interfaces.Persistance.UserRepositories;
using GarmentShop.Application.Tests.XUnit.Auth.Commands.TestUtils;
using GarmentShop.Application.Tests.XUnit.Auth.TestUtils;
using GarmentShop.Application.Tests.XUnit.TestUtils.Auth;
using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.AuthenticationAggregate.ValueObjects;
using GarmentShop.Domain.UserAggregate;
using GarmentShop.Domain.UserAggregate.Entities;
using GarmentShop.Domain.UserAggregate.ValueObjects;
using Moq;
using System.Linq.Expressions;
using GarmentShop.Domain.Common.Errors;
using GarmentShop.Application.Common.Interfaces.Persistance.AuthRepositories;

namespace GarmentShop.Application.Tests.XUnit.Auth.Commands.Register
{
    public class RegisterCommandHandlerTests
    {
        private readonly Mock<IJwtTokenGenerator> jwtTokenGeneratorMock;
        private readonly Mock<IUnitOfWork> unitOfWorkMock;
        private readonly RegisterCommandHandler handler;
        private readonly Mock<IUserRepository> userRepositoryMock;
        private readonly RegisterCommandValidator validator;
        private readonly Mock<IGenericRepository<Role, RoleId>> roleRepositoryMock;
        private readonly Mock<IAuthRepository> authRepositoryMock;

        private readonly Mock<
           IGenericRepository<
               Authentication, AuthenticationId>> authGenRepositoryMock;

        public RegisterCommandHandlerTests()
        {
            jwtTokenGeneratorMock = new();
            unitOfWorkMock = new();
            userRepositoryMock = new();
            authGenRepositoryMock = new();
            validator = new();
            roleRepositoryMock = new();
            authRepositoryMock = new();
            handler = new RegisterCommandHandler(
                jwtTokenGeneratorMock.Object,
                unitOfWorkMock.Object,
                authRepositoryMock.Object);
        }

        [Fact]
        public async Task HandleRegisterCommand_ValidCommand_ReturnsAuthenticationResult()
        {
            // Arrange
            var registerCommand = RegisterCommandUtils.RegisterCommand();
            var role = RegisterCommandUtils.CreateRole();
            var user = AuthUtils.CreateUser();
            var registeringUser = AuthUtils.CreateAuthUserWithValidPassword(user);
            var jwtToken = AuthUtils.GenerateJwtToken();

            authRepositoryMock
                .Setup(x => x.IsEmailNotUniqueAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            authRepositoryMock
                .Setup(x => x.IsUsernameNotUniqueAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            unitOfWorkMock
                .Setup(x =>
                    x.GetRepository<Authentication, AuthenticationId>(false))
                .Returns(authGenRepositoryMock.Object);

            unitOfWorkMock
                .Setup(x => x.GetRepository<Role, RoleId>(false))
                .Returns(roleRepositoryMock.Object);

            roleRepositoryMock
                .Setup(x => x.FirstOrDefaultAsync(
                    It.IsAny<Expression<Func<Role, bool>>>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(role);

            unitOfWorkMock
                .Setup(x => x.GetRepository<User, UserId>(true))
                .Returns(userRepositoryMock.Object);

            userRepositoryMock
                .Setup(x => x.AddRoleAsync(
                    It.IsAny<User>(),
                    It.IsAny<Role>()))
                .Verifiable();

            userRepositoryMock
                .Setup(x => x.AddAsync(
                    It.IsAny<User>(),
                    It.IsAny<CancellationToken>()))
                .Verifiable();

            authGenRepositoryMock
                .Setup(x => x.AddAsync(
                    It.IsAny<Authentication>(),
                    It.IsAny<CancellationToken>()))
                .Verifiable();

            jwtTokenGeneratorMock
                .Setup(x => x.GenerateToken(
                    It.IsAny<Authentication>(),
                    It.IsAny<User>()))
                .Returns(jwtToken);

            // Act
            var result = await handler.Handle(registerCommand, CancellationToken.None);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.ValidateCreatedFrom(registeringUser, jwtToken);

            userRepositoryMock.Verify(x =>
                x.AddRoleAsync(It.IsAny<User>(), It.IsAny<Role>()), Times.Once);

            userRepositoryMock.Verify(x =>
                x.AddAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()), Times.Once);

            authRepositoryMock.Verify(x =>
                x.IsEmailNotUniqueAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);

            authRepositoryMock.Verify(x =>
                x.IsUsernameNotUniqueAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);

            authGenRepositoryMock
                .Verify(x => x.AddAsync(
                    It.IsAny<Authentication>(),
                    It.IsAny<CancellationToken>()), Times.Once);

            unitOfWorkMock.Verify(x =>
                x.SaveChangesAsync(CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task HandleRegisterCommand_DuplicateEmail_ReturnsDuplicateEmailError()
        {
            // Arrange
            var registerCommand = RegisterCommandUtils.RegisterCommand();

            authRepositoryMock
                .Setup(x => x.IsEmailNotUniqueAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var result = await handler.Handle(registerCommand, CancellationToken.None);

            // Assert
            result.IsError.Should().BeTrue();
            result.Errors.FirstOrDefault().Should().Be(Errors.User.DuplicateEmail);

            unitOfWorkMock.Verify(x => 
                x.SaveChangesAsync(CancellationToken.None), Times.Never);
        }

        [Fact]
        public async Task HandleRegisterCommand_DuplicateUsername_ReturnsDuplicateUsernameError()
        {
            // Arrange
            var registerCommand = RegisterCommandUtils.RegisterCommand();

            authRepositoryMock
                .Setup(x => x.IsUsernameNotUniqueAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var result = await handler.Handle(registerCommand, CancellationToken.None);

            // Assert
            result.IsError.Should().BeTrue();
            result.Errors.FirstOrDefault().Should().Be(Errors.User.DuplicateUsername);

            unitOfWorkMock.Verify(x =>
                x.SaveChangesAsync(CancellationToken.None), Times.Never);
        }
    }
}