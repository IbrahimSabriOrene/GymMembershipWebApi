using ErrorOr;
using MediatR;
using MemberInfo.Domain.Products;

namespace MemberInfo.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string ProductName,
    List<Prices> Price,
    int Months,
    List<PersonIds> PersonIdList
): IRequest<ErrorOr<Product>>;


public record Prices (
    int Amount,
    string Currency
);

public record PersonIds (
    Guid Id
);