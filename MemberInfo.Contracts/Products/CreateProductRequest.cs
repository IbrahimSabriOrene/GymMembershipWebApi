namespace MemberInfo.Contracts.Products;

public record CreateProductRequest
(
    string ProductName,
    List<Prices> Price,
    int Months,
    List<ProductIds> PersonIds
);