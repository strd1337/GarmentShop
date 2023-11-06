using GarmentShop.Domain.UserAggregate.ValueObjects;
using GarmentShop.Domain.SaleAggregate.ValueObjects;
using GarmentShop.Domain.UserAggregate.Entities;
using GarmentShop.Domain.Common.Models;

namespace GarmentShop.Domain.UserAggregate
{
    public sealed class User : AggregateRoot<UserId, Guid>
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

        public void AddRole(Role role)
        {
            roles.Add(UserRole.Create(role));
        }

        public void UpdateInformation(
            UserDetailInformation updatedInformation)
        {
            Information = updatedInformation;
        }

#pragma warning disable CS8618
        private User() 
        {
        }
#pragma warning restore CS8618
    }
}
