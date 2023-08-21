namespace MemberInfo.Contracts.Products;

public record ProductResponse
(
    string ProductId,
    string ProductName,
    string Price,
    int Months,
    DateTime CreationDate,
    DateTime? LastUpdateDate,
    List<string> PersonIds
);
