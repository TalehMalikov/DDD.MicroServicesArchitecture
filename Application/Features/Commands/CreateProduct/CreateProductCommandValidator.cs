
using FluentValidation;

namespace Application.Features.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .WithMessage("'Name'i boş kecme.")
                .MaximumLength(20)
                .MinimumLength(3)
                .WithMessage("'Name' deyeri 3 ile 20 character arasında olmalıdır.");
            RuleFor(p => p.Price)
                .Must(p => p > 0)
                .WithMessage("'Price' deyerini doğru girin.");
        }
    }
}
