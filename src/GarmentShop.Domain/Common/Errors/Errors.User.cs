using ErrorOr;

namespace GarmentShop.Domain.Common.Errors
{
    public static partial class Errors
    { 
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(
                code: "User.DuplicateEmail",
                description: "Email is already in use.");

            public static Error DuplicateUsername => Error.Conflict(
                code: "User.DuplicateUsername",
                description: "Username is already in use.");

            public static Error NotFound => Error.NotFound(
                code: "User.NotFound",
                description: "User is not found.");

            public static Error DataConflict => Error.Conflict(
                code: "User.DataConflict",
                description: "Data conflict: " +
                    "The provided data is the same as the existing data.");
        }
    }
}
