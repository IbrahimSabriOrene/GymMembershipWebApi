namespace MemberInfo.Contracts.Products;

public record CreateProductRequest
(
    string ProductName,
    List<Prices> Price,
    int Months,
    Guid PersonIds
);

//Request only has one PersonId, but the command has a list of PersonIds.
// we are coming here but im not use why the personId is not being passed in personIdList as return