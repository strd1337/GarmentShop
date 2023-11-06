using FluentValidation;

namespace GarmentShop.Application.Users.Commands.UserProfileUpdate
{
    public class UserProfileUpdateValidator 
        : AbstractValidator<UserProfileUpdateCommand>
    {
        public UserProfileUpdateValidator()
        {
            RuleFor(r => r.FirstName)
                .NotEmpty()
                    .WithMessage("First name is required")
                .MaximumLength(50)
                    .WithMessage("First name cannot exceed 50 characters");

            RuleFor(r => r.LastName)
                .NotEmpty()
                    .WithMessage("Last name is required")
                .MaximumLength(50)
                    .WithMessage("Last name cannot exceed 50 characters");

            RuleFor(r => r.PhoneNumber)
                .NotEmpty()
                    .WithMessage("Phone number is required")
                .Matches(@"^\d{10,}$")
                    .WithMessage("Phone number must be at least 10 digits")
                .MaximumLength(30)
                    .WithMessage("Phone number cannot exceed 30 digits");

            RuleFor(r => r.Address)
                .NotEmpty()
                    .WithMessage("Address is required")
                .MaximumLength(200)
                    .WithMessage("Address cannot exceed 200 characters");

            RuleFor(r => r.City)
                .NotEmpty()
                    .WithMessage("City is required")
                .MaximumLength(50)
                    .WithMessage("City cannot exceed 50 characters");

            RuleFor(r => r.ZipCode)
                .NotEmpty()
                    .WithMessage("Zip code is required")
                .MaximumLength(10)
                    .WithMessage("Zip code cannot exceed 10 characters");

            RuleFor(r => r.Country)
                .NotEmpty()
                    .WithMessage("Country is required")
                .MaximumLength(50)
                    .WithMessage("Country cannot exceed 50 characters");
        }
    }
}