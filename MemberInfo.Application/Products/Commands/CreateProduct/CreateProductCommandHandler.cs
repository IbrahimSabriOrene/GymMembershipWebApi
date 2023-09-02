using ErrorOr;
using MediatR;
using MemberInfo.Domain.Common.Interfaces.Persistence;
using MemberInfo.Domain.Person.ValueObjects;
using MemberInfo.Domain.Products;
using MemberInfo.Domain.Products.ValueObjects;
using MemberInfo.Domain.Common.Errors;

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

        var  personIds = request.PersonIds.Select(property => PersonId.Create(property.Id)).ToHashSet();
        

        var product = Product.Create(
            productName: request.ProductName,
            prices: request.Price.Select(property => Price.Create(
                property.Amount,
                property.Currency)).ToList(),
            months: request.Months,
            personIds: personIds  // This will change soon.
            );

        if(product is null)
        {
            return Errors.NullReference.ProductNotFound("Product not found");
        }
        if (product.Id is null)
        {
            return Errors.NullReference.ProductNotFound("Product not found");
        }
            

            _productRepository.Add(product);

          //what we could do=> PersonId.CreateUnique(request.PersonId.Id) but if we do this we are only passing one personId.
            

            //Possible way to do this: Change createUnique to create and pass the person's id as a parameter.

            //Problems with the above line:
            //Lets make it work for now
            // We are gonna implement the user's guid id to the personId.
        return product;
    }
}
