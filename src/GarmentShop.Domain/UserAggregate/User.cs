using GarmentShop.Domain.UserAggregate.ValueObjects;
using GarmentShop.Domain.Models;
using GarmentShop.Domain.SaleAggregate.ValueObjects;
using GarmentShop.Domain.UserAggregate.Entities;

namespace GarmentShop.Domain.UserAggregate
{
    public sealed class User : AggregateRoot<UserId>
    { 
        private readonly List<UserRole> roles = new();
        private readonly List<SaleId> saleIds = new();

        public UserDetailInformation Information { get; private set; }
        public IReadOnlyList<UserRole> Roles => roles.AsReadOnly(); 
        public IReadOnlyList<SaleId> SaleIds => saleIds.AsReadOnly();

        private User(
            UserId id,
            UserDetailInformation information) : base(id)
        {
            Information = information;
        }

        public static User Create(
            UserDetailInformation information)
        { 
            return new User(
                UserId.CreateUnique(),
                information); 
        }

        public void AddSale(SaleId id)
        {
            saleIds.Add(id);
        }

        public void AddRole(UserRole role)
        {
            roles.Add(role);
        }

#pragma warning disable CS8618
        private User() 
        {
        }
#pragma warning restore CS8618
    }
}
