namespace GarmentShop.Contracts.User.UpdateProfile
{
    public record UserProfileUpdateRequest(
        Guid UserId,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Address,
        string City,
        string ZipCode,
        string Country);
}