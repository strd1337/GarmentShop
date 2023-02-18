using GarmentShop.Domain.Common.Models;

namespace GarmentShop.Domain.UserAggregate.ValueObjects
{
    public class UserDetailInformation : ValueObject
    {
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? PhoneNumber { get; private set; }
        public string? Address { get; private set; }
        public string? City { get; private set; }
        public string? ZipCode { get; private set; }
        public string? Country { get; private set; }

        private UserDetailInformation(
            string? firstName,
            string? lastName,
            string? phoneNumber,
            string? address,
            string? city,
            string? zipCode,
            string? country)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
            City = city;
            ZipCode = zipCode;
            Country = country;
        }

        public static UserDetailInformation CreateNew(
            string? firstName = null,
            string? lastName = null,
            string? phoneNumber = null,
            string? address = null,
            string? city = null,
            string? zipCode = null,
            string? country = null)
        {
            return new(
                firstName,
                lastName,
                phoneNumber,
                address,
                city,
                zipCode,
                country);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {

            yield return FirstName ?? "";
            yield return FirstName ?? "";
            yield return LastName ?? "";
            yield return PhoneNumber ?? "";
            yield return Address ?? "";
            yield return City ?? "";
            yield return ZipCode ?? "";
            yield return Country ?? "";
        }

#pragma warning disable CS8618
        private UserDetailInformation()
        { 
        }
#pragma warning restore CS8618
    }
}