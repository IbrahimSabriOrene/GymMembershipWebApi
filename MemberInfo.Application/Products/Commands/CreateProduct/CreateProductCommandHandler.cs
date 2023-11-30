using ErrorOr;
using MediatR;
using Customer.Domain.Common.Interfaces.Persistence;
using Customer.Domain.Person.ValueObjects;
using Customer.Domain.Products;
using Customer.Domain.Products.ValueObjects;
using Customer.Domain.Common.Errors;

namespace Customer.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<Product>>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<Product>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // var personIds -> check if personIds exists in the database. then add it to the product. if not, return error.
        var personIds = command.PersonIds.Select(property => PersonId.Insert(property.Id)).ToHashSet();
        // We should change PersonId.Create to get personBy id.
        // Because we are creating a product, we should get the person by id.
        // Something like, insert person by id first, check if user exists, if not, return error.


        var product = Product.Create(
            productName: command.ProductName,
            prices: command.Price.Select(property => Price.Create(
                property.Amount,
                property.Currency)).ToList(),
            months: command.Months,
            personIds: personIds  // This will change soon.
            );

        if (product is null)
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
