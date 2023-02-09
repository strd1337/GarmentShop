using GarmentShop.Domain.AuthenticationAggregate.ValueObjects;
using GarmentShop.Domain.Models;

namespace GarmentShop.Domain.AuthenticationAggregate
{
    public sealed class Authentication : AggregateRoot<AuthenticationId>
    {
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string Salt { get; private set; }
        public string Role { get; private set; }
          
        private Authentication(
            AuthenticationId id,
            string userName,
            string email,
            string passwordHash,
            string salt,
            string role) : base(id)
        {
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            Salt = salt;
            Role = role;
        }

        public static Authentication Create(
            string userName,
            string email,
            string passwordHash,
            string salt,
            string role)
        {
            return new(
                AuthenticationId.CreateUnique(),
                userName,
                email,
                passwordHash,
                salt,
                role);
        }
    }
}
