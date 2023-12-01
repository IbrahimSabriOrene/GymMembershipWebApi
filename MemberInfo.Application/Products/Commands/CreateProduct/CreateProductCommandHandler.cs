using ErrorOr;
using MediatR;
using Customer.Domain.Common.Interfaces.Persistence;
using Customer.Domain.Person.ValueObjects;
using Customer.Domain.Products;
using Customer.Domain.Products.ValueObjects;
using Customer.Domain.Common.Errors;
using MemberInfo.Domain.Common.Interfaces.Persistence;


namespace Customer.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<Product>>
{
    private readonly IProductRepository _productRepository;
    private readonly ICustomerRepository _customerRepository;

    public CreateProductCommandHandler(IProductRepository productRepository, ICustomerRepository customerRepository)
    {
        _productRepository = productRepository;
        _customerRepository = customerRepository;
    }

    public async Task<ErrorOr<Product>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        // We should change PersonId.Create to get personBy id.
        // Because we are creating a product, we should get the person by id.
        // Something like, insert person by id first, check if user exists, if not, return error.


        var product = Product.Create(
            productName: command.ProductName,
            prices: command.Price.Select(property => Price.Create(
                property.Amount,
                property.Currency)).ToList(),
            months: command.Months
           
            );

        if (product is null)
        {
            return Errors.NullReference.ProductNotFound("Product not found");
        }

        _productRepository.Add(product);

        
        return product;
    }
}
