
namespace MemberInfo.Contracts.Products;

public record ProductResponse
(
    Guid ProductId,
    string ProductName,
    List<Prices> Price,
    int Months,
    DateTime CreationDate,
    DateTime? LastUpdateDate,
    List<PersonIds> PersonIds
);


public record Prices
(
    int Amount,
    string Currency

);

public record PersonIds
(
    Guid Id
);
//Compare this snippet from MemberInfo.Application\Products\Queries\GetProduct\GetProductQueryHandler.cs: