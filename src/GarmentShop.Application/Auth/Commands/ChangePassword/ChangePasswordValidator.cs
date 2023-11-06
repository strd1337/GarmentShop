using FluentValidation;

namespace GarmentShop.Application.Auth.Commands.ChangePassword
{
    public class ChangePasswordValidator
        : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordValidator()
        {
            RuleFor(r => r.CurrentPassword)
                .NotEmpty()
                    .WithMessage("Current password is required");

            RuleFor(r => r.ConfirmNewPassword)
                .NotEmpty()
                    .WithMessage("Confirmation of the new password is required");

            RuleFor(r => r.NewPassword)
                .NotEmpty()
                    .WithMessage("New password is required")
                .MinimumLength(6)
                    .WithMessage("New password must have at least 6 characters")
                .MaximumLength(20)
                    .WithMessage("New password cannot have more than 20 characters")
                .Matches("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{6,}$")
                    .WithMessage("New password must contain at least one " +
                        "number and one uppercase letter")
                .Equal(r => r.ConfirmNewPassword) 
                    .WithMessage("New password and confirmation do not match")
                .NotEqual(r => r.CurrentPassword)
                    .WithMessage("New password must be different from the old password");
        }
    }
}
