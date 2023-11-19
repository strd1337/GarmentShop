using GarmentShop.Domain.GarmentCategoryAggregate.ValueObjects;
using GarmentShop.Domain.UserAggregate.ValueObjects;

namespace GarmentShop.Infrastructure.Persistance.IdentityManagement
{
    public sealed class IdentityGenerator
    {
        private readonly List<GarmentCategoryId> garmentCategoryIds = new();
        private readonly List<RoleId> roleIds = new();

        private readonly int garmentCategoryIdsCount = 4;
        private readonly int roleIdsCount = 3;

        public IReadOnlyList<RoleId> RoleIds => roleIds.AsReadOnly();
        public IReadOnlyList<GarmentCategoryId> GarmentCategoryIds => 
            garmentCategoryIds.AsReadOnly();

        private IdentityGenerator()
        {
            GenerateRoleIds();
            GenerateGarmentCategoryIds();
        }

        public static IdentityGenerator Create()
        {
            return new IdentityGenerator();
        }

        private void GenerateGarmentCategoryIds()
        {
            for (int i = 0; i < garmentCategoryIdsCount; ++i)
            {
                garmentCategoryIds.Add(GarmentCategoryId.CreateUnique());
            }
        }
        
        private void GenerateRoleIds()
        {
            for (int i = 0; i < roleIdsCount; ++i)
            {
                roleIds.Add(RoleId.CreateUnique());
            }
        }
    }
}
