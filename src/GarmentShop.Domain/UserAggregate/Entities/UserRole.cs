using GarmentShop.Domain.Models;
using GarmentShop.Domain.UserAggregate.Enums;
using GarmentShop.Domain.UserAggregate.ValueObjects;

namespace GarmentShop.Domain.UserAggregate.Entities
{
    public sealed class UserRole : Entity<UserRoleId>
    {
        private readonly List<Permission> permissions = new(); 

        public string Name { get; private set; }
        public RoleType Type { get; private set; }
        public IReadOnlyList<Permission> Permissions 
            => permissions.AsReadOnly();

        private UserRole(
            UserRoleId id,
            string name,
            RoleType type) : base(id)
        {
            Name = name;
            Type = type;
        }

        public static UserRole Create(
            string name,
            RoleType type)
        {
            return new(
                UserRoleId.CreateUnique(),
                name,
                type);
        }

        public void AddPermission(Permission permission)
        {
            permissions.Add(permission);
        }

#pragma warning disable CS8618
        private UserRole()
        {
        }
#pragma warning restore CS8618
    }
}
