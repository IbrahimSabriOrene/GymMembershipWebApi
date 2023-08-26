using ErrorOr;
using MediatR;
using MemberInfo.Application.Common.Interfaces.Persistence;
using MemberInfo.Domain.Person.ValueObjects;
using MemberInfo.Domain.Products;
using MemberInfo.Domain.Products.ValueObjects;

namespace MemberInfo.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<Product>>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var product = Product.Create(
            productName: request.ProductName,
            prices: request.Price.ConvertAll(x => Price.Create(x.Amount, x.Currency)),
            months: request.Months,
            personIds: request.PersonIds.ConvertAll(x => PersonId.CreateUnique(x.Id))// Problem: PersonIdList can not be null, but it is null.
            );

            _productRepository.Add(product);

          //what we could do=> PersonId.CreateUnique(request.PersonId.Id) but if we do this we are only passing one personId.
            

            //Possible way to do this: Change createUnique to create and pass the person's id as a parameter.

            //Problems with the above line:
            //Lets make it work for now
            // We are gonna implement the user's guid id to the personId.
        return product;
    }
}
