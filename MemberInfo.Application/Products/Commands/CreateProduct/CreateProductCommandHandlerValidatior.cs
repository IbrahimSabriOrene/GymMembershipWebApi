using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Customer.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandlerValidatior : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandHandlerValidatior()
    {
        RuleFor(x => x.ProductName).NotEmpty().WithMessage("Product Name is required");
        RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
        RuleFor(x => x.Months).NotEmpty().WithMessage("Months is required");

    }
}
