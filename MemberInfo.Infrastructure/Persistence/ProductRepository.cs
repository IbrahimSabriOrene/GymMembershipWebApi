using Customer.Domain.Common.Errors;
using Customer.Domain.Common.Interfaces.Persistence;
using Customer.Domain.Products;
using Customer.Domain.Products.ValueObjects;
using MemberInfo.Domain.Common.Interfaces.Services;

namespace Customer.Infrastructure.Persistence;

public class ProductRepository : IProductRepository
{
    private readonly IDbContext _dbContext;
    public ProductRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private static readonly List<Product> _products = new();
    public void Add(Product product)
    {
        _products.Add(product);
    }


    public Product? FindById(Guid Id)
    {
        var productId = ProductId.Insert(Id);
        var product = _products.FirstOrDefault(x => x.Id == productId);
        if (product is null)
        {
            return null;
        }
        else return product;
    }
}
