using MemberInfo.Domain.Models;

namespace MemberInfo.Domain.Products.ValueObjects;

public sealed class ProductId : ValueObject
{
    public Guid Value { get ;}
    
    public ProductId(Guid value)
    {
        Value = value;
    }

    public static ProductId CreateUnique(){

        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
