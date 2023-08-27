using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemberInfo.Domain.Models;
using MemberInfo.Domain.ProductAggregate.ValueObjects;

namespace MemberInfo.Domain.ProductAggregate;

public sealed class Product : AggregateRoot<ProductId>
{
    public string ProductName { get; }
    public int Months { get; }
    public decimal Price { get; }


    public Product(
        ProductId id,
        string productName,
        int months,
        decimal price) : base(id)
    {
        ProductName = productName;
        Months = months;
        Price = price;
    }
    

    public static Product Create(
        string productName,
        int months,
        decimal price)
    {
        var productId = ProductId.Create();
        return new Product(
            productId,
            productName,
            months,
            price);
    }
    
}
