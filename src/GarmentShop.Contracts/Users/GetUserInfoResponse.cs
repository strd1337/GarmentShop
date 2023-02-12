namespace GarmentShop.Contracts.Users
{
    public record GetUserInfoResponse(
         string Id,
         string FirstName,
         string LastName,
         string PhoneNumber,
         string Address,
         string City,
         string ZipCode,
         string Country,
         List<string> SaleIds);
}