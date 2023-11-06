using ErrorOr;

namespace GarmentShop.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials => Error.Validation(
                code: "Auth.InvalidCredentials",
                description: "Invalid credentials.");

            public static Error InvalidOldPassword => Error.Validation(
                code: "Auth.InvalidOldPassword",
                description: "The old password is incorrect.");
        }
    }
}
