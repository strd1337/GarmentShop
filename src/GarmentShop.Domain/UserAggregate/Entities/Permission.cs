using GarmentShop.Domain.Common.Models;
using GarmentShop.Domain.UserAggregate.Enums;
using GarmentShop.Domain.UserAggregate.ValueObjects;

namespace GarmentShop.Domain.UserAggregate.Entities
{
    public sealed class Permission : Entity<PermissionId>
    {
        public string Name { get; private set; }
        public PermissionType Type { get; private set; }

        private Permission(
            PermissionId id,
            string name,
            PermissionType type) : base(id)
        {
            Name = name;
            Type = type;
        }

        public static Permission Create(
            string name,
            PermissionType type)
        {
            return new(
                PermissionId.CreateUnique(),
                name,
                type);
        }

#pragma warning disable CS8618
        private Permission()
        {
        }
#pragma warning restore CS8618
    }
}
