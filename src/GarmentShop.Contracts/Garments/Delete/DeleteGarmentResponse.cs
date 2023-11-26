namespace GarmentShop.Contracts.Garments.Delete
{
    public record DeleteGarmentResponse(
        Guid GarmentId,
        string Name);
}