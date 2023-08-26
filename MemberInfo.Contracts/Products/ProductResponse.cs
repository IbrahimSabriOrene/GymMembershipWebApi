
namespace MemberInfo.Contracts.Products;

public record ProductResponse
(
    Guid ProductId,  // Product Response not mapped correctly 
    string ProductName,
    List<Prices> Price,
    int Months,
    DateTime CreationDate,
    DateTime? LastUpdateDate,
    Guid PersonId

);


public record Prices
(
    int Amount,
    string Currency

);

//Compare this snippet from MemberInfo.Application\Products\Queries\GetProduct\GetProductQueryHandler.cs: