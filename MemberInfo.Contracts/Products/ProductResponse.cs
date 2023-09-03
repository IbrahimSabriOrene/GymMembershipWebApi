
namespace MemberInfo.Contracts.Products;

public record ProductResponse
(
    Guid ProductId,  // Product Response not mapped correctly 
    string ProductName,
    List<Prices> Price,
    int Months,
    DateTime CreationDate,
    DateTime LastUpdateDate,
    HashSet<PersonIds> PersonId

);


public record Prices
(
    int Amount,
    string Currency

);

public record PersonIds
(
    Guid Id // PersonIds not mapped correctly
);
