using MemberInfo.Domain.Common.Errors;
using MemberInfo.Domain.Common.Interfaces.Persistence;
using MemberInfo.Domain.Products;
using MemberInfo.Domain.Products.ValueObjects;

namespace MemberInfo.Infrastructure.Persistence;

public class ProductRepository : IProductRepository
{
    private static readonly List<Product> _products = new();
    public void Add(Product product)
    {
        _products.Add(product);
    }

    public Product? FindById(ProductId productId)
    {
        var product = _products.FirstOrDefault(x => x.Id == productId);


        return product;
    }
}
