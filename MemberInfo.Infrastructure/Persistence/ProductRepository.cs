using MemberInfo.Domain.Common.Interfaces.Persistence;
using MemberInfo.Domain.Products;

namespace MemberInfo.Infrastructure.Persistence;

public class ProductRepository : IProductRepository
{
    private static readonly List<Product> _products = new();
    public void Add(Product product)
    {
        _products.Add(product);
    }
}
