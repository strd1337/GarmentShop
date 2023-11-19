namespace GarmentShop.Contracts.GarmentTypes.Dtos
{
    public record GarmentTypeDto(
        Guid TypeId,
        string Name,
        string Description,
        Guid CategoryId);
}
