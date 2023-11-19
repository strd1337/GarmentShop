namespace GarmentShop.Contracts.GarmentCategories.Dtos
{
    public record GarmentCategoryDto(
        Guid CategoryId,
        string Name,
        string Description);
}
