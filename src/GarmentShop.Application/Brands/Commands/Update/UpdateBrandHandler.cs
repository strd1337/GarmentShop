using ErrorOr;
using GarmentShop.Application.Brands.Common;
using GarmentShop.Application.Common.CQRS;
using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Domain.BrandAggregate;
using GarmentShop.Domain.BrandAggregate.ValueObjects;
using GarmentShop.Domain.Common.Errors;
using GarmentShop.Domain.Events.Brand;

namespace GarmentShop.Application.Brands.Commands.Update
{
    public class UpdateBrandHandler
        : ICommandHandler<UpdateBrandCommand, UpdateBrandResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateBrandHandler(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<UpdateBrandResult>> Handle(
            UpdateBrandCommand command,
            CancellationToken cancellationToken)
        {
            Brand? brand = await unitOfWork
                .GetRepository<Brand, BrandId>()
                .GetByIdAsync(
                    BrandId.Create(command.BrandId),
                    cancellationToken);

            if (brand is null)
            {
                return Errors.Brand.NotFound;
            }

            if (brand.Name == command.Name)
            {
                return Errors.Brand.DataConflict;
            }

            brand.Update(command.Name, command.Description);

            await unitOfWork
                .GetRepository<Brand, BrandId>()
                .UpdateAsync(brand);

            brand.RaiseDomainEvent(new BrandUpdatedEvent(
                Guid.NewGuid(),
                brand.Id.Value,
                brand.Name,
                brand.Description));

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return new UpdateBrandResult(
                brand.Id.Value,
                brand.Name,
                brand.Description);
        }
    }
}
