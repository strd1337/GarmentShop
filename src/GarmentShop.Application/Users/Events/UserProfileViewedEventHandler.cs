using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Application.Common.Services;
using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.AuthenticationAggregate.ValueObjects;
using GarmentShop.Domain.Common.Events;
using GarmentShop.Domain.Events.User;
using Microsoft.Extensions.Logging;

namespace GarmentShop.Application.Users.Events
{
    public sealed class UserProfileViewedEventHandler :
        IDomainEventHandler<UserProfileViewedEvent>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<UserProfileViewedEventHandler> logger;
        private readonly IDateTimeProvider dateTimeProvider;
        
        public UserProfileViewedEventHandler(
            IUnitOfWork unitOfWork,
            ILogger<UserProfileViewedEventHandler> logger,
            IDateTimeProvider dateTimeProvider)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task Handle(
            UserProfileViewedEvent notification, 
            CancellationToken cancellationToken)
        {
            var authUser = await unitOfWork
               .GetRepository<Authentication, AuthenticationId>()
               .GetByIdAsync(
                    AuthenticationId.Create(notification.AuthId),
                    cancellationToken);

            if (authUser is null)
            {
                logger.LogInformation(
                    "User is not found in database during viewing profile. " +
                    "{@DateTimeUtc}", dateTimeProvider.UtcNow);

                return;
            }

            logger.LogInformation(
                "User viewed own profile AuthId: {@AuthId}, " +
                "UserId: {@UserId}, Date: {@DateTimeUtc}",
                authUser.Id.Value, authUser.UserId.Value,
                dateTimeProvider.UtcNow);

            return;
        }
    }
}
