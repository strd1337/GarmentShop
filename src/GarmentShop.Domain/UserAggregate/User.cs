using GarmentShop.Domain.AuthenticationAggregate.ValueObjects;
using GarmentShop.Domain.UserAggregate.ValueObjects;
using GarmentShop.Domain.Models;
using GarmentShop.Domain.SalesAggregate.ValueObjects;

namespace GarmentShop.Domain.UserAggregate
{
    public sealed class User : AggregateRoot<UserId>
    {
        private readonly List<SaleId> saleIds = new(); 

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; } 
        public string Country { get; private set; }
        public AuthenticationId AuthenticationId { get; private set; }

        public IReadOnlyList<SaleId> SaleIds => saleIds.AsReadOnly();

        private User(
            UserId id, 
            string firstName,
            string lastName,
            string phoneNumber,
            string address,
            string city,
            string zipCode, 
            string country,
            AuthenticationId authenticationId) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
            City = city;
            ZipCode = zipCode;
            Country = country;
            AuthenticationId = authenticationId;
        }

        public static User Create(
            string firstName,
            string lastName,
            string phoneNumber,
            string address,
            string city,
            string zipCode,
            string country,
            AuthenticationId authenticationId)
        { 
            return new User(
                UserId.CreateUnique(),
                firstName,
                lastName,
                phoneNumber,
                address,
                city,
                zipCode,
                country,
                authenticationId); 
        }

        public void AddSale(SaleId saleId)
        {
            saleIds.Add(saleId);
        }
         
        public void RemoveSale(SaleId saleId)
        {
            saleIds.Remove(saleId);
        }
    }
}
