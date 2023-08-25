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
            personIds: request.PersonIdList.ConvertAll(x => PersonId.CreateUnique(request.PersonIds)).ToList()); // This part has to take the person's id from the database.
            
            //Problem: PersonIdList can not be null, but it is null.
            //Possible way to do this: Change createUnique to create and pass the person's id as a parameter.

            //Problems with the above line:
            //Lets make it work for now
            // We are gonna implement the user's guid id to the personId.
        return default!;
    }
}
