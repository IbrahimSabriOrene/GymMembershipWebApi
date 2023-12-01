using ErrorOr;
using MediatR;
using Customer.Domain.Products;

namespace Customer.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string ProductName,
    List<PricesCommand> Price,
    int Months
) : IRequest<ErrorOr<Product>>;
//Add product Id here.

public record PricesCommand(
    int Amount,
    string Currency
);

