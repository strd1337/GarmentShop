using FluentValidation;

namespace GarmentShop.Application.Auth.Queries.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email address");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must have at least 6 characters")
                .MaximumLength(20).WithMessage("Password cannot have more than 20 characters")
                .Matches("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{6,}$")
                .WithMessage("Password must contain at least one " +
                    "number and one uppercase letter");
        }
    }
}
