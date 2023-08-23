using ErrorOr;
using MediatR;
using MemberInfo.Domain.Person.ValueObjects;
using MemberInfo.Domain.Products;
using MemberInfo.Domain.Products.ValueObjects;

namespace MemberInfo.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<Product>>
{
    public Task<ErrorOr<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Product.Create(
            productName: request.ProductName,
            prices: request.Price.ConvertAll(x => Price.Create(x.Amount, x.Currency)).ToList(),
            months: request.Months,
            personIds: request.PersonIds.ConvertAll(x => PersonId.CreateUnique()).ToList());

            //Problems with the above line:
            // We are creating the Person's id inside the Product's domain, which is not correct.
            // We have to get the person's id from the database, but we don't have access to the database here.
            //Lets make it work for now
            // We are gonna implement the user's guid id to the personId.
        return default;
    }
}
