
namespace MemberInfo.Contracts.Products;

public record ProductResponse
(
    string ProductId,
    string ProductName,
    List<Prices> Price,
    int Months,
    DateTime CreationDate,
    DateTime? LastUpdateDate,
    List<ProductIds> PersonIds
);


public record Prices
(
    int Amount,
    string Currency

);

public record ProductIds
(
    Guid Id
);

