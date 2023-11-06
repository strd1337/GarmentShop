namespace GarmentShop.Contracts.User.Profile
{
    public record UserProfileResponse(
        Guid UserId,
        string UserName,
        string Email,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Address,
        string City,
        string ZipCode,
        string Country);
}