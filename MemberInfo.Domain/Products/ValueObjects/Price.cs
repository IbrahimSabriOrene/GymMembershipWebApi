using Customer.Domain.Models;

namespace Customer.Domain.Products.ValueObjects;

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

    public static Price Create(int amount, string currency)
    {
        // Purpose: Creates a new instance of the 'Price' value object.
        // Usage: Used to create a new instance of the 'Price' value object.

        return new Price(amount, currency);
    }
}
