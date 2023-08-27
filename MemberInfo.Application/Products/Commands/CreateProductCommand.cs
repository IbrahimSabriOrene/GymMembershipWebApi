using ErrorOr;
using MediatR;

namespace MemberInfo.Application.Products.Commands;
using Product = Domain.ProductAggregate.Product;


public class CreateProductCommand : IRequest<ErrorOr<Product>>
{
    public string ProductName { get; }
    public int Months { get; }
    public decimal Price { get; }

    public CreateProductCommand(
        string productName,
        int months,
        decimal price)
    {
        ProductName = productName;
        Months = months;
        Price = price;

    }


}