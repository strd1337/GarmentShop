using GarmentShop.Domain.AuthenticationAggregate.ValueObjects;
using GarmentShop.Domain.Common.Models;
using GarmentShop.Domain.Events.Auth;
using GarmentShop.Domain.UserAggregate.ValueObjects;

namespace GarmentShop.Domain.AuthenticationAggregate
{
    public sealed class Authentication : AggregateRoot<AuthenticationId>
    {
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string Salt { get; private set; }
        public UserId UserId { get; private set; } 

        private Authentication(
            AuthenticationId id,
            string userName,
            string email,
            string passwordHash,
            string salt,
            UserId userId) : base(id) 
        {
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            Salt = salt;
            UserId = userId;
        }

        public static Authentication Create(
            string userName,
            string email,
            string passwordHash,
            string salt,
            UserId userId)
        {
            var registeredUser = new Authentication(
                AuthenticationId.CreateUnique(),
                userName,
                email,
                passwordHash,
                salt,
                userId);

            registeredUser.RaiseDomainEvent(
                new UserRegisteredEvent(
                    Guid.NewGuid(),
                    registeredUser.Id.Value, 
                    registeredUser.UserId.Value));

            return registeredUser;
        }
                
#pragma warning disable CS8618
        private Authentication()
        {
        }
#pragma warning restore CS8618
    }
}