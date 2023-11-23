using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Application.Common.Services;
using GarmentShop.Domain.BrandAggregate;
using GarmentShop.Domain.BrandAggregate.ValueObjects;
using GarmentShop.Domain.Common.Events;
using GarmentShop.Domain.Events.Brand;
using Microsoft.Extensions.Logging;

namespace GarmentShop.Application.Brands.Events
{
    public sealed class BrandCreatedEventHandler
        : IDomainEventHandler<BrandCreatedEvent>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<BrandCreatedEventHandler> logger;
        private readonly IDateTimeProvider dateTimeProvider;

        public BrandCreatedEventHandler(
            IUnitOfWork unitOfWork,
            ILogger<BrandCreatedEventHandler> logger,
            IDateTimeProvider dateTimeProvider)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task Handle(
            BrandCreatedEvent notification,
            CancellationToken cancellationToken)
        {
            var brandCreated = await unitOfWork
                .GetRepository<Brand, BrandId>()
                .GetByIdAsync(
                    BrandId.Create(notification.BrandId),
                    cancellationToken);

            if (brandCreated is null)
            {
                logger.LogInformation(
                    "Created brand is not found in database " +
                    "during creating. {@DateTimeUtc}",
                    dateTimeProvider.UtcNow);

                return;
            }

            logger.LogInformation(
                "Created brand BrandId: {@BrandId}, Date: {@DateTimeUtc}",
                brandCreated.Id.Value, dateTimeProvider.UtcNow);

            return;
        }
    }
}
