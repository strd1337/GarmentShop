namespace GarmentShop.Contracts.Authentication
{
    public record AuthenticationResponse(
        Guid AuthId,
        Guid UserId,
        string UserName,
        string Email,
        string Token); 
} 
