using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemberInfo.Domain.Products;

namespace MemberInfo.Application.Common.Interfaces.Persistence;

public interface IProductRepository
{
    void Add(Product product);
}
