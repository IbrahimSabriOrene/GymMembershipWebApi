namespace MemberInfo.Contracts.Products;

public record CreateProductRequest
(
    string Id,
    string ProductName,
    string Price,
    int Months,
    string PersonIds
);
