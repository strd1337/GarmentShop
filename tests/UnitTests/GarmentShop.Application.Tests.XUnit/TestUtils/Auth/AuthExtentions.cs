using FluentAssertions;
using GarmentShop.Application.Auth.Common;
using GarmentShop.Domain.AuthenticationAggregate;

namespace GarmentShop.Application.Tests.XUnit.TestUtils.Auth
{
    public static class AuthExtentions
    {
        public static void ValidateCreatedFrom(
            this AuthenticationResult result,
            Authentication authUser,
            string jwtToken)
        {
            result.Token.Should().Be(jwtToken);

            result.User.Id.Should().Be(authUser.Id);
            result.User.UserName.Should().Be(authUser.UserName);
            result.User.Email.Should().Be(authUser.Email);
            result.User.PasswordHash.Should().Be(authUser.PasswordHash);
            result.User.Salt.Should().Be(authUser.Salt);
            result.User.UserId.Should().Be(authUser.UserId);
        }
    }
}