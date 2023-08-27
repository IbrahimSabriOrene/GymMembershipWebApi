namespace MemberInfo.Application.Common.Interfaces.Persistence;
using Product = Domain.ProductAggregate.Product;

public interface IProductRepository
{
    void Add(Product product);

}