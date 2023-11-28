using Customer.Domain.Common.Errors;
using Customer.Domain.Common.Interfaces.Persistence;
using Customer.Domain.Products;
using Customer.Domain.Products.ValueObjects;

namespace Customer.Infrastructure.Persistence;

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
        //need if else statement

        return product;
    }

    public bool Exists(ProductId productId)
    {
        var product = _products.FirstOrDefault(x => x.Id == productId);
        if (product is not null)
        {
            return true;
        }
        else return false;
        /*
        if (product == null)
        {
            throw new ProductNotFoundException(productId);
        }
        */

    }
}
