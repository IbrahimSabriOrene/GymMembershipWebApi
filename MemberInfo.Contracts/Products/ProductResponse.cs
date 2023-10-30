
namespace Customer.Contracts.Products;

public record ProductResponse
(
    Guid ProductId,
    string ProductName,
    List<Prices> Price,
    int Months,
    DateTime CreationDate,
    DateTime LastUpdateDate,
    HashSet<PersonIds> PersonId

);



