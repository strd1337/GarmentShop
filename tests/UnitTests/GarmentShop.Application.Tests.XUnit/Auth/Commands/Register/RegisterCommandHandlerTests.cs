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

        private readonly Mock<
           IGenericRepository<
               Authentication, AuthenticationId>> authRepositoryMock;

        public RegisterCommandHandlerTests() 
        {
            jwtTokenGeneratorMock = new();
            unitOfWorkMock = new();
            userRepositoryMock = new();
            authRepositoryMock = new();
            validator = new();
            roleRepositoryMock = new();
            handler = new RegisterCommandHandler(
                jwtTokenGeneratorMock.Object,
                unitOfWorkMock.Object);
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
            Authentication? authUser = null; 

            unitOfWorkMock
                .Setup(x =>
                    x.GetRepository<Authentication, AuthenticationId>(false))
                .Returns(authRepositoryMock.Object);

            authRepositoryMock
                .Setup(x => x.FirstOrDefaultAsync(
                    It.IsAny<Expression<Func<Authentication, bool>>>(), 
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(authUser);

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

            authRepositoryMock
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

            authRepositoryMock
                .Verify(x => x.FirstOrDefaultAsync(
                    It.IsAny<Expression<Func<Authentication, bool>>>(), 
                    It.IsAny<CancellationToken>()), Times.Once);
            
            authRepositoryMock
                .Verify(x => x.AddAsync(
                    It.IsAny<Authentication>(), 
                    It.IsAny<CancellationToken>()), Times.Once);

            unitOfWorkMock.Verify(x => 
                x.SaveChangesAsync(CancellationToken.None), Times.Once);
        } 
    }
}