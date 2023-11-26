using ErrorOr;
using GarmentShop.Application.Common.CQRS;
using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Application.Garments.Common;
using GarmentShop.Domain.GarmentAggregate;
using GarmentShop.Domain.GarmentAggregate.ValueObjects;
using GarmentShop.Domain.Common.Errors;
using GarmentShop.Domain.Events.Garment;

namespace GarmentShop.Application.Garments.Commands.Delete
{
    public class DeleteGarmentHandler
        : ICommandHandler<DeleteGarmentCommand, DeleteGarmentResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteGarmentHandler(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<DeleteGarmentResult>> Handle(
            DeleteGarmentCommand command,
            CancellationToken cancellationToken)
        {
            Garment? garment = await unitOfWork
                .GetRepository<Garment, GarmentId>()
                .GetByIdAsync(
                    GarmentId.Create(command.GarmentId),
                    cancellationToken);

            if (garment is null)
            {
                return Errors.Garment.NotFound;
            }

            await unitOfWork
                .GetRepository<Garment, GarmentId>()
                .RemoveAsync(garment);

            garment.RaiseDomainEvent(new GarmentDeletedEvent(
                Guid.NewGuid(),
                garment.Id.Value,
                garment.Name));

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteGarmentResult(
                garment.Id.Value,
                garment.Name);
        }
    }
}
