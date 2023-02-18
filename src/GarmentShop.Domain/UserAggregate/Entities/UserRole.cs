using GarmentShop.Domain.Common.Models;
using GarmentShop.Domain.UserAggregate.ValueObjects;

namespace GarmentShop.Domain.UserAggregate.Entities
{
    public sealed class UserRole : Entity<UserRoleId>
    {
        public Role Role { get; private set; }
       
        private UserRole(
            UserRoleId id,
            Role role) : base(id)
        {
            Role = role;
        }

        public static UserRole Create(Role role)
        {
            return new(
                UserRoleId.CreateUnique(),
                role);
        }

#pragma warning disable CS8618
        private UserRole()
        {
        }
#pragma warning restore CS8618
    }
}
