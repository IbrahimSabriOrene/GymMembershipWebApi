using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemberInfo.Application.Common.Interfaces.Persistence;
using MemberInfo.Domain.ProductAggregate;

namespace MemberInfo.Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly MemberInfoDbContext _context;

    public ProductRepository(MemberInfoDbContext context)
    {
        _context = context;
    }

    public void Add(Product product)
    {
        _context.Add(product);
        _context.SaveChanges();
    }
}
