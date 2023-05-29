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
using GarmentShop.Domain.Common.Errors;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using FluentValidation.TestHelper;

namespace GarmentShop.Application.Tests.XUnit.Auth.Queries.Login
{
    public class LoginQueryHandlerTests
    {
        private readonly Mock<IJwtTokenGenerator> jwtTokenGeneratorMock;
        private readonly Mock<IUnitOfWork> unitOfWorkMock;
        private readonly LoginQueryHandler handler;
        private readonly Mock<IUserRepository> userRepositoryMock;
        private readonly LoginQueryValidator validator;

        private readonly Mock<
            IGenericRepository<
                Authentication, AuthenticationId>> authRepositoryMock;

        public LoginQueryHandlerTests()
        {
            jwtTokenGeneratorMock = new();
            unitOfWorkMock = new();
            userRepositoryMock = new();
            authRepositoryMock = new();
            validator = new();
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
            var authUser = AuthUtils.CreateAuthUserWithValidPassword(user);
            var jwtToken = AuthUtils.GenerateJwtToken();

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

            // Act
            var result = await handler.Handle(loginQuery, CancellationToken.None);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.ValidateCreatedFrom(authUser, jwtToken);

            authUser.GetDomainEvents().Should().ContainSingle(e => e is UserLoggedInEvent);
            unitOfWorkMock.Verify(x => x.SaveChangesAsync(CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task HandleLoginQuery_InvalidPassword_ReturnsInvalidCredentialsError()
        {
            // Arrange
            var loginQuery = LoginQueryUtils.LoginQuery();
            var user = AuthUtils.CreateUser();
            var authUser = AuthUtils.CreateAuthUserWithInvalidPassword(user);

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

            // Act
            var result = await handler.Handle(loginQuery, CancellationToken.None);

            // Assert
            result.IsError.Should().BeTrue();
            result.Errors.FirstOrDefault().Should().Be(Errors.Authentication.InvalidCredentials);

            unitOfWorkMock.Verify(x => x.SaveChangesAsync(CancellationToken.None), Times.Never);
        }

        [Fact]
        public async Task HandleLoginQuery_AuthUserIsNull_ReturnsInvalidCredentialsError()
        {
            // Arrange
            var loginQuery = LoginQueryUtils.LoginQuery();
            Authentication? authUser = null;

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

            // Act
            var result = await handler.Handle(loginQuery, CancellationToken.None);

            // Assert
            result.IsError.Should().BeTrue();
            result.Errors.FirstOrDefault().Should().Be(Errors.Authentication.InvalidCredentials);

            unitOfWorkMock.Verify(x => x.SaveChangesAsync(CancellationToken.None), Times.Never);
        }

        [Theory]
        [InlineData(null, "Password1", "Email is required")]
        [InlineData("", "Password1", "Email is required")]
        [InlineData("invalid-email", "Password1", "Invalid email address")]
        public void ValidateLoginQuery_InvalidEmail_ShouldHaveValidationErrors(
            string email, 
            string password, 
            string expectedErrorMessage)
        {
            // Arrange
            var loginQuery = new LoginQuery(email, password);

            // Act
            var result = validator.TestValidate(loginQuery);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Email)
                .WithErrorMessage(expectedErrorMessage);
        }

        [Theory]
        [InlineData("test@example.com", null, "Password is required")]
        [InlineData("test@example.com", "", "Password is required")]
        [InlineData("test@example.com", "short", "Password must have at least 6 characters")]
        [InlineData("test@example.com", "verylongpasswordthatexceedscharacterlimit", "Password cannot have more than 20 characters")]
        [InlineData("test@example.com", "password", "Password must contain at least one number and one uppercase letter")]
        [InlineData("test@example.com", "PASSWORD", "Password must contain at least one number and one uppercase letter")]
        public void ValidateLoginQuery_InvalidPassword_ShouldHaveValidationErrors(
            string email,
            string password,
            string expectedErrorMessage)
        {
            // Arrange
            var loginQuery = new LoginQuery(email, password);

            // Act
            var result = validator.TestValidate(loginQuery);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Password)
                .WithErrorMessage(expectedErrorMessage);
        }
    }
}
