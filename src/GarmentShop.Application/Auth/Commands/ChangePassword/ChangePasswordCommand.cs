using GarmentShop.Application.Auth.Common;
using GarmentShop.Application.Common.CQRS;

namespace GarmentShop.Application.Auth.Commands.ChangePassword
{
    public record ChangePasswordCommand(
        string UserName,
        string CurrentPassword,
        string NewPassword,
        string ConfirmNewPassword) : ICommand<AuthenticationResult>;
}
