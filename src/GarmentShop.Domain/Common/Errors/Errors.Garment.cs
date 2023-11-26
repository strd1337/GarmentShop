using ErrorOr;

namespace GarmentShop.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Garment
        {
            public static Error DuplicateGarment => Error.Conflict(
                code: "Garment.DuplicateGarment",
                description: "Garment already exists.");

            public static Error NotFound => Error.NotFound(
                code: "Garment.NotFound",
                description: "Garment is not found.");

            public static Error DataConflict => Error.Conflict(
                code: "Garment.DataConflict",
                description: "Data conflict: " +
                    "The provided data is the same as the existing data.");
        }
    }
}
