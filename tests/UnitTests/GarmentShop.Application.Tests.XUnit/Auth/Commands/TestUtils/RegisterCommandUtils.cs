using GarmentShop.Application.Auth.Commands.Register;
using GarmentShop.Application.Tests.XUnit.TestUtils.Constants;
using GarmentShop.Domain.UserAggregate.Entities;
using GarmentShop.Domain.UserAggregate.Enums;

namespace GarmentShop.Application.Tests.XUnit.Auth.Commands.TestUtils
{
    public static class RegisterCommandUtils
    {
        public static RegisterCommand RegisterCommand() =>
            new(
                Constants.Auth.UserName,
                Constants.Auth.Email,
                Constants.Auth.Password
            );

        public static Role CreateRole() =>
            Role.Create(
                Constants.Auth.RoleName,
                RoleType.Customer);
    }
}
