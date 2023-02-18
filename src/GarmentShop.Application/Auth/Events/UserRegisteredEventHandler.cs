using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Domain.Common.Events;
using GarmentShop.Domain.Events;

namespace GarmentShop.Application.Auth.Events
{
    public sealed class UserRegisteredEventHandler
        : IDomainEventHandler<UserRegisteredEvent>
    {
        private readonly IUnitOfWork unitOfWork;

        public UserRegisteredEventHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task Handle(
            UserRegisteredEvent notification,
            CancellationToken cancellationToken)
        {
           /* var registeredUser = await unitOfWork
               .AuthenticationRepository
               .GetByIdAsync(notification.AuthId, cancellationToken);


            if (registeredUser is null)
            {
                return;
            }

            // email service && log event*/

            return Task.CompletedTask;
        }
    }
}
