using ErrorOr;
using MemberInfo.Domain.Common.Errors;
using MemberInfo.Domain.Models;

namespace MemberInfo.Domain.Products.ValueObjects;

public sealed class ProductId : ValueObject
{
    public Guid Value { get ; private set;}
    
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
