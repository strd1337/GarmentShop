using GarmentShop.Application.Auth.Queries.Login;
using GarmentShop.Application.Tests.XUnit.TestUtils.Constants;

namespace GarmentShop.Application.Tests.XUnit.Auth.Queries.TestUnils
{
    public static class LoginQueryUtils
    {
        public static LoginQuery LoginQuery() =>
            new(
                Constants.Auth.Email,
                Constants.Auth.Password
            );
    }
}
