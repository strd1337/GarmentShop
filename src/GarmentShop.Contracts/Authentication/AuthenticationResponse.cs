namespace GarmentShop.Contracts.Authentication
{
    public record AuthenticationResponse(
        Guid Id,
        Guid UserId,
        string UserName,
        string Email,
        string Token); 
} 
