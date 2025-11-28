using FluentValidation;
using InnoShop.ProductsManagementService.Application.Dtos.Requests;

namespace InnoShop.ProductsManagementService.Application.Validators;

public class CreateProductValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Price).GreaterThan(0);
    }
}
