using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemberInfo.Domain.Models;

namespace MemberInfo.Domain.ProductAggregate.ValueObjects;

public sealed class ProductId: ValueObject
{
    public Guid Value { get; }

    public ProductId(Guid value)
    {
        Value = value;
    }


    public static ProductId Create()
    {
        return new ProductId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
