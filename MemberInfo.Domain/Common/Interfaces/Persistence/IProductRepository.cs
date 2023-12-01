using Customer.Domain.Products;

namespace Customer.Domain.Common.Interfaces.Persistence;

public interface IProductRepository
{
    void Add(Product product);
    Product? FindById(Guid Id);

}
