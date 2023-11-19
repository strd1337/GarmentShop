using GarmentShop.Contracts.GarmentTypes.Dtos;

namespace GarmentShop.Contracts.GarmentTypes.GetAll
{
    public record GetAllGarmentTypesResponse(
        ICollection<GarmentTypeDto> Types);
}
