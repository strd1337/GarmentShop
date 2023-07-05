using GarmentShop.Application.Tests.XUnit.TestUtils.Constants;
using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.UserAggregate;
using GarmentShop.Domain.UserAggregate.ValueObjects;

namespace GarmentShop.Application.Tests.XUnit.Auth.TestUtils
{
    public static class AuthUtils
    {
        public static Authentication CreateAuthUserWithValidPassword(User user)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            return Authentication.Create(
                Constants.Auth.UserName,
                Constants.Auth.Email,
                BCrypt.Net.BCrypt.HashPassword(Constants.Auth.Password, salt),
                salt,
                UserId.Create(user.Id.Value)
            );
        }

        public static Authentication CreateAuthUserWithInvalidPassword(User user)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            return Authentication.Create(
                Constants.Auth.UserName,
                Constants.Auth.Email,
                BCrypt.Net.BCrypt.HashPassword(Constants.Auth.InvalidPassword, salt),
                salt,
                UserId.Create(user.Id.Value)
            );
        }

        public static User CreateUser() =>
            User.Create(CreateUserDetailInformation());

        public static UserDetailInformation CreateUserDetailInformation() =>
            UserDetailInformation.CreateNew(
                Constants.Auth.UserName,
                Constants.Auth.LastName,
                Constants.Auth.PhoneNumber,
                Constants.Auth.Address,
                Constants.Auth.City,
                Constants.Auth.ZipCode,
                Constants.Auth.Country
            );

        public static string GenerateJwtToken() =>
            Constants.Auth.JwtToken;
    }
}