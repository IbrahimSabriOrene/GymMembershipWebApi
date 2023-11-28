using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Domain.Products;
using Customer.Domain.Products.ValueObjects;

namespace Customer.Domain.Common.Interfaces.Persistence;

public interface IProductRepository
{
    void Add(Product product);
    bool Exists(ProductId productId);

    Product? FindById(ProductId productId);
}
