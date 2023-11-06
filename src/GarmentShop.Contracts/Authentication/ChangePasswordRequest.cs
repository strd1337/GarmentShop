namespace GarmentShop.Contracts.Authentication
{
    public record ChangePasswordRequest(
        string UserName,
        string CurrentPassword,
        string NewPassword,
        string ConfirmNewPassword);
}
