using ErrorOr;
using MediatR;
using MemberInfo.Application.Common.Interfaces.Persistence;
using MemberInfo.Application.Products.Commands;

namespace MemberInfo.Application.Product.Commands;
using Product = Domain.ProductAggregate.Product;
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<Product>>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<Product>> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var product = Product.Create
        (
            request.ProductName,
            request.Months,
            request.Price
        );

        _productRepository.Add(product);

        return product;
    }
}