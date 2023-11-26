using ErrorOr;
using GarmentShop.Application.Common.CQRS;
using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Application.Common.Interfaces.Persistance.Garments;
using GarmentShop.Application.Garments.Common;
using GarmentShop.Domain.BrandAggregate;
using GarmentShop.Domain.BrandAggregate.ValueObjects;
using GarmentShop.Domain.Common.Errors;
using GarmentShop.Domain.GarmentAggregate;
using GarmentShop.Domain.GarmentAggregate.Enums;
using GarmentShop.Domain.GarmentAggregate.ValueObjects;
using GarmentShop.Domain.GarmentTypeAggregate;
using GarmentShop.Domain.GarmentTypeAggregate.ValueObjects;

namespace GarmentShop.Application.Garments.Commands.Create
{
    public class CreateGarmentHandler
        : ICommandHandler<CreateGarmentCommand, CreateGarmentResult>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGarmentRepository garmentRepository;

        public CreateGarmentHandler(
            IUnitOfWork unitOfWork,
            IGarmentRepository garmentRepository)
        {
            this.unitOfWork = unitOfWork;
            this.garmentRepository = garmentRepository;
        }

        public async Task<ErrorOr<CreateGarmentResult>> Handle(
            CreateGarmentCommand command,
            CancellationToken cancellationToken)
        {
            if (await garmentRepository.IsGarmentNotUniqueAsync(
                command.Name, cancellationToken))
            {
                return Errors.Garment.DuplicateGarment;
            }
            
            Brand? brand = await unitOfWork
                .GetRepository<Brand, BrandId>()
                .GetByIdAsync(
                    BrandId.Create(command.BrandId),
                    cancellationToken);

            if (brand is null)
            {
                return Errors.Brand.NotFound;
            }

            GarmentType? garmentType = await unitOfWork
                .GetRepository<GarmentType, GarmentTypeId>()
                .GetByIdAsync(
                    GarmentTypeId.Create(command.GarmentTypeId),
                    cancellationToken);

            if (garmentType is null)
            {
                return Errors.GarmentType.NotFound;
            }

            var newGarment = Garment.Create(
                command.Name,
                command.Description,
                command.Price,
                (Size)command.Size,
                (Color)command.Color,
                (Material)command.Material,
                command.AvailableQuantity,
                BrandId.Create(command.BrandId),
                GarmentTypeId.Create(command.GarmentTypeId));

            await unitOfWork
                .GetRepository<Garment, GarmentId>()
                .AddAsync(newGarment, cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return new CreateGarmentResult(
                newGarment.Id.Value,
                newGarment.BrandId.Value,
                newGarment.GarmentTypeId.Value,
                newGarment.Name,
                newGarment.Description,
                newGarment.Price,
                newGarment.Size.ToString(),
                newGarment.Color.ToString(),
                newGarment.Material.ToString(),
                newGarment.AvailableQuantity);
        }
    }
}
