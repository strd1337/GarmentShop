using ErrorOr;

namespace GarmentShop.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class GarmentType
        {
            public static Error NotFound => Error.NotFound(
                code: "GarmentType.NotFound",
                description: "Garment type is not found.");
        }
    }
}
