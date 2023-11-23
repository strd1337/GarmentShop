using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Application.Common.Services;
using GarmentShop.Domain.BrandAggregate;
using GarmentShop.Domain.BrandAggregate.ValueObjects;
using GarmentShop.Domain.Common.Events;
using GarmentShop.Domain.Events.Brand;
using Microsoft.Extensions.Logging;

namespace GarmentShop.Application.Brands.Events
{
    public sealed class BrandUpdatedEventHandler
        : IDomainEventHandler<BrandUpdatedEvent>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<BrandUpdatedEventHandler> logger;
        private readonly IDateTimeProvider dateTimeProvider;

        public BrandUpdatedEventHandler(
            IUnitOfWork unitOfWork,
            ILogger<BrandUpdatedEventHandler> logger,
            IDateTimeProvider dateTimeProvider)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task Handle(
            BrandUpdatedEvent notification,
            CancellationToken cancellationToken)
        {
            var brandUpdated = await unitOfWork
                .GetRepository<Brand, BrandId>()
                .GetByIdAsync(
                    BrandId.Create(notification.BrandId),
                    cancellationToken);

            if (brandUpdated is null)
            {
                logger.LogInformation(
                    "Updated brand is not found in database " +
                    "during creating. {@DateTimeUtc}",
                    dateTimeProvider.UtcNow);

                return;
            }

            logger.LogInformation(
                "Updated brand BrandId: {@BrandId}, Date: {@DateTimeUtc}",
                brandUpdated.Id.Value, dateTimeProvider.UtcNow);

            return;
        }
    }
}
