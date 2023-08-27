using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemberInfo.Application.Common.Interfaces.Persistence;
using MemberInfo.Domain.ProductAggregate;

namespace MemberInfo.Infrastructure.Persistence;

public class ProductRepository : IProductRepository
{
    private static readonly List<Product> _products = new();


    public void Add(Product product)
    {
        _products.Add(product);
    }
}
