using FluentValidation;

namespace GarmentShop.Application.Auth.Commands.Register
{
    public class RegisterCommandValidator 
        : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator() 
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                    .WithMessage("Username is required")
                .MinimumLength(5)
                    .WithMessage("Username must have at least 5 characters")
                .MaximumLength(15)
                    .WithMessage("Username cannot have more than 15 characters");

            RuleFor(r => r.Email)
                .NotEmpty()
                    .WithMessage("Email is required")
                .EmailAddress()
                    .WithMessage("Email is not valid");

            RuleFor(r => r.Password)
                .NotEmpty()
                    .WithMessage("Password is required")
                .MinimumLength(6)
                    .WithMessage("Password must have at least 6 characters")
                .MaximumLength(20)
                    .WithMessage("Password cannot have more than 20 characters")
                .Matches("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{6,}$")
                    .WithMessage("Password must contain at least one " +
                        "number and one uppercase letter");
        }   
    }
}
