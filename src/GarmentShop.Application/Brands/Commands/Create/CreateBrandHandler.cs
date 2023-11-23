using ErrorOr;
using GarmentShop.Application.Brands.Common;
using GarmentShop.Application.Common.CQRS;
using GarmentShop.Domain.Common.Errors;
using GarmentShop.Application.Common.Interfaces.Persistance.Brands;
using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Domain.BrandAggregate;
using GarmentShop.Domain.BrandAggregate.ValueObjects;

namespace GarmentShop.Application.Brands.Commands.Create
{
    public class CreateBrandHandler
        : ICommandHandler<CreateBrandCommand, CreateBrandResult>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IBrandRepository brandRepository;

        public CreateBrandHandler(
            IUnitOfWork unitOfWork,
            IBrandRepository brandRepository)
        {
            this.unitOfWork = unitOfWork;
            this.brandRepository = brandRepository;
        }

        public async Task<ErrorOr<CreateBrandResult>> Handle(
            CreateBrandCommand command,
            CancellationToken cancellationToken)
        {
            if (await brandRepository.IsBrandNotUniqueAsync(
                command.Name, cancellationToken))
            {
                return Errors.Brand.DuplicateBrand;
            }

            Brand newBrand = Brand.Create(
                command.Name,
                command.Description);

            await unitOfWork
                .GetRepository<Brand, BrandId>()
                .AddAsync(newBrand, cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return new CreateBrandResult(
                newBrand.Id.Value,
                newBrand.Name,
                newBrand.Description);
        }
    }
}
