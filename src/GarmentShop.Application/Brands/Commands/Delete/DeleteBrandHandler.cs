using ErrorOr;
using GarmentShop.Domain.Common.Errors;
using GarmentShop.Application.Brands.Common;
using GarmentShop.Application.Common.CQRS;
using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Domain.BrandAggregate;
using GarmentShop.Domain.BrandAggregate.ValueObjects;
using GarmentShop.Domain.Events.Brand;

namespace GarmentShop.Application.Brands.Commands.Delete
{
    public class DeleteBrandHandler
        : ICommandHandler<DeleteBrandCommand, DeleteBrandResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteBrandHandler(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<DeleteBrandResult>> Handle(
            DeleteBrandCommand command,
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

            await unitOfWork
                .GetRepository<Brand, BrandId>()
                .RemoveAsync(brand);

            brand.RaiseDomainEvent(new BrandDeletedEvent(
                Guid.NewGuid(),
                brand.Id.Value,
                brand.Name,
                brand.Description));

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteBrandResult(
                brand.Id.Value,
                brand.Name,
                brand.Description);
        }
    }
}
