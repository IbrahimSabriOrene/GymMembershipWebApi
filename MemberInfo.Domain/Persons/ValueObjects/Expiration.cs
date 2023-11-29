using Customer.Domain.Models;

namespace Customer.Domain.Persons.ValueObjects;

public sealed class Expiration : ValueObject
{
    public DateTime _expirationDate;

    public Expiration(DateTime expirationDate)
    {
        _expirationDate = expirationDate;
    }

    public bool HasExpired()
    {
        return _expirationDate < DateTime.UtcNow;
    }


    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return _expirationDate;
    }

    public static Expiration Create(DateTime expirationDate)
    {
        return new(expirationDate);
    }
    public static Expiration GetExpiration(DateTime expirationDate)
    {
        return new(expirationDate);
    }
    public DateTime Value
    {
        get { return _expirationDate; }
    }
}

