using ErrorOr;
using GarmentShop.Application.Common.CQRS;
using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Application.GarmentTypes.Common;
using GarmentShop.Domain.GarmentTypeAggregate;
using GarmentShop.Domain.GarmentTypeAggregate.ValueObjects;

namespace GarmentShop.Application.GarmentTypes.Queries
{
    public class GetAllGarmentTypesHandler
        : IQueryHandler<GetAllGarmentTypesQuery, GetAllGarmentTypesResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllGarmentTypesHandler(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<GetAllGarmentTypesResult>> Handle(
            GetAllGarmentTypesQuery query,
            CancellationToken cancellationToken)
        {
            var types = await unitOfWork
                .GetRepository<GarmentType, GarmentTypeId>()
                .GetAllAsync(cancellationToken);

            return new GetAllGarmentTypesResult(types.ToList());
        }
    }
}
