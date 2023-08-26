using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace MemberInfo.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandlerValidatior : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandHandlerValidatior()
    {
        RuleFor(x => x.ProductName).NotEmpty();
        RuleFor(x => x.Price).NotEmpty();
        RuleFor(x => x.Months).NotEmpty();
        RuleFor(x => x.PersonId).NotEmpty();
    }
}
