using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemberInfo.Domain.Products;
using MemberInfo.Domain.Products.ValueObjects;

namespace MemberInfo.Domain.Common.Interfaces.Persistence;

public interface IProductRepository
{
    void Add(Product product);
    
    Product? FindById(ProductId productId);
}
