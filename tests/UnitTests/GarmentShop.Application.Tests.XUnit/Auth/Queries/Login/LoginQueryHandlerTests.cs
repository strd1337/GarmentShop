using FluentAssertions;
using GarmentShop.Application.Auth.Queries.Login;
using GarmentShop.Application.Common.Interfaces.Auth;
using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Application.Common.Interfaces.Persistance.UserRepositories;
using GarmentShop.Application.Tests.XUnit.Auth.Queries.TestUnils;
using GarmentShop.Application.Tests.XUnit.Auth.TestUtils;
using GarmentShop.Application.Tests.XUnit.TestUtils.Auth;
using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.AuthenticationAggregate.ValueObjects;
using GarmentShop.Domain.Events.Auth;
using GarmentShop.Domain.UserAggregate;
using GarmentShop.Domain.UserAggregate.ValueObjects;
using Moq;
using System.Linq.Expressions;

namespace GarmentShop.Application.Tests.XUnit.Auth.Queries.Login
{
    public class LoginQueryHandlerTests
    {
        private readonly Mock<IJwtTokenGenerator> jwtTokenGeneratorMock;
        private readonly Mock<IUnitOfWork> unitOfWorkMock;
        private readonly LoginQueryHandler handler;
        private readonly Mock<IUserRepository> userRepositoryMock;

        private readonly Mock<
            IGenericRepository<
                Authentication, AuthenticationId>> authRepositoryMock;

        public LoginQueryHandlerTests()
        {
            jwtTokenGeneratorMock = new();
            unitOfWorkMock = new();
            userRepositoryMock = new();
            authRepositoryMock = new();
            handler = new LoginQueryHandler(
                jwtTokenGeneratorMock.Object,
                unitOfWorkMock.Object);
        }

        [Fact]
        public async Task HandleLoginQuery_ValidCredentials_ReturnsAuthenticationResult() 
        {
            // Arrange
            var loginQuery = LoginQueryUtils.LoginQuery();
            var user = AuthUtils.CreateUser();
            var authUser = AuthUtils.CreateAuthUser(user);
            var jwtToken = AuthUtils.GenerateJwtToken();

            // Act
            unitOfWorkMock
                .Setup(x => 
                    x.GetRepository<Authentication, AuthenticationId>(false))
                .Returns(authRepositoryMock.Object);

            authRepositoryMock
                .Setup(x => 
                    x.FirstOrDefaultAsync(
                        It.IsAny<Expression<Func<Authentication,
                        bool>>>(), 
                        It.IsAny<CancellationToken>()))
                .ReturnsAsync(authUser);

            unitOfWorkMock.Setup(x => x.GetRepository<User, UserId>(true))
                .Returns(userRepositoryMock.Object);

            userRepositoryMock
                .Setup(x => 
                    x.FindByIdAsync(
                        authUser.UserId, 
                        It.IsAny<CancellationToken>()))
                .ReturnsAsync(user);

            jwtTokenGeneratorMock
                .Setup(x => x.GenerateToken(authUser, user))
                .Returns(jwtToken);

            var result = await handler.Handle(loginQuery, CancellationToken.None);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.ValidateCreatedFrom(authUser, jwtToken);

            authUser.GetDomainEvents().Should().ContainSingle(e => e is UserLoggedInEvent);
            unitOfWorkMock.Verify(x => x.SaveChangesAsync(CancellationToken.None), Times.Once);
        }
    }
}
