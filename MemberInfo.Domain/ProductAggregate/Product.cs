using MemberInfo.Domain.Models;
using MemberInfo.Domain.ProductAggregate.ValueObjects;

namespace MemberInfo.Domain.ProductAggregate;

public sealed class Product : AggregateRoot<ProductId>
{
    public string ProductName { get; private set; }
    public int Months { get; private set; }
    public decimal Price { get; private set; }

    // Existing constructor
    private Product(
        ProductId id,
        string productName,
        int months,
        decimal price) : base(id)
    {
        ProductName = productName;
        Months = months;
        Price = price;
    }
    
    // EF Core parameterless constructor
    public Product() 
    {
    }

    public static Product Create(
        string productName,
        int months,
        decimal price)
    {
        return new Product(
            ProductId.Create(),
            productName,
            months,
            price);
    }
}

    

