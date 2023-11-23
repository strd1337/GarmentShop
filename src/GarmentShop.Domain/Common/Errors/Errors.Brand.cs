using ErrorOr;

namespace GarmentShop.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Brand
        {
            public static Error DuplicateBrand => Error.Conflict(
                code: "Brand.DuplicateBrand",
                description: "Brand already exists.");

            public static Error NotFound => Error.NotFound(
                code: "Brand.NotFound",
                description: "Brand is not found.");

            public static Error DataConflict => Error.Conflict(
                code: "Brand.DataConflict",
                description: "Data conflict: " +
                    "The provided data is the same as the existing data.");
        }
    }
}
