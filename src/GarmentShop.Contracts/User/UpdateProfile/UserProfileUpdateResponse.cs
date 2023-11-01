namespace GarmentShop.Contracts.User.UpdateProfile
{
    public record UserProfileUpdateResponse(
        Guid UserId,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Address,
        string City,
        string ZipCode,
        string Country);
}
