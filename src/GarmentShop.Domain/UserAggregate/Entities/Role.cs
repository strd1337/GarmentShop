using GarmentShop.Domain.Common.Models;
using GarmentShop.Domain.UserAggregate.Enums;
using GarmentShop.Domain.UserAggregate.ValueObjects;

namespace GarmentShop.Domain.UserAggregate.Entities
{
    public sealed class Role : Entity<RoleId>
    {
        private readonly List<Permission> permissions = new();

        public string Name { get; private set; }
        public RoleType Type { get; private set; }
        public IReadOnlyList<Permission> Permissions
            => permissions.AsReadOnly();

        private Role(
            RoleId id,
            string name,
            RoleType type) : base(id)
        {
            Name = name;
            Type = type;
        }

        public static Role Create(
            string name,
            RoleType type)
        {
            return new(
                RoleId.CreateUnique(),
                name,
                type);
        }

        public void AddPermission(Permission permission)
        {
            permissions.Add(permission);
        }
    }
}
