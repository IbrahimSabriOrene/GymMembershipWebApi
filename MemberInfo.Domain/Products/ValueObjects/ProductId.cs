using ErrorOr;
using Customer.Domain.Common.Errors;
using Customer.Domain.Models;

namespace Customer.Domain.Products.ValueObjects;

public sealed class ProductId : ValueObject
{
    public Guid Value { get; private set; }

    public ProductId(Guid value)
    {

        Value = value;
    }

    public static ProductId CreateUnique()
    {

        return new(Guid.NewGuid()); // this will change
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }


}
