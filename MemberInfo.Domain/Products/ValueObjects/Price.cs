using MemberInfo.Domain.Models;

namespace MemberInfo.Domain.Products.ValueObjects;

public sealed class Price : ValueObject
{
    public int Amount { get; private set; }
    public string Currency { get; private set; }

    public Price(int amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        // Purpose: Defines the equality components for the 'Price' value object.
        // Usage: Specifies the properties that are considered for equality comparison.

        yield return Amount;
        yield return Currency;
    }
}
