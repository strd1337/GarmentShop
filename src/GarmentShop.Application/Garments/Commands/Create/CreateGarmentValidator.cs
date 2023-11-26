using FluentValidation;

namespace GarmentShop.Application.Garments.Commands.Create
{
    public class CreateGarmentValidator
        : AbstractValidator<CreateGarmentCommand>
    {
        public CreateGarmentValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Name is required")
                .MinimumLength(3)
                    .WithMessage("Name must have at least 3 characters")
                .MaximumLength(50)
                    .WithMessage("Name cannot have more than 50 characters");

            RuleFor(r => r.Description)
                .NotEmpty()
                    .WithMessage("Description is required")
                .MinimumLength(10)
                    .WithMessage("Description must have at least 10 characters")
                .MaximumLength(200)
                    .WithMessage("Description cannot have more than 200 characters");

            RuleFor(x => x.Price)
                .NotEmpty()
                    .WithMessage("Price is required.")
                .GreaterThan(0)
                    .WithMessage("Price must be greater than zero.")
                .LessThanOrEqualTo(99999999)
                    .WithMessage("Price must be less than or equal to 99999999.");
        }
    }
}
