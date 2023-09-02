using ErrorOr;
using MediatR;
using MemberInfo.Domain.Products;

namespace MemberInfo.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string ProductName,
    List<PricesCommand> Price,
    int Months,
    HashSet<PersonIdsCommand> PersonIds //This place gonna change.
): IRequest<ErrorOr<Product>>;


public record PricesCommand (
    int Amount,
    string Currency
);

public record PersonIdsCommand(
    Guid Id
);

