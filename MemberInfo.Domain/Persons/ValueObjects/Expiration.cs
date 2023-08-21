using MemberInfo.Domain.Models;

namespace MemberInfo.Domain.Persons.ValueObjects;

public sealed class Expiration : ValueObject
{
    public DateTime ExpirationDate { get; }

    public Expiration(DateTime expirationDate)
    {
        ExpirationDate = expirationDate;
    }

    public  bool HasExpired()
    {
        return ExpirationDate < DateTime.UtcNow;
    }


    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return ExpirationDate;
    }

    public static Expiration Create(DateTime expirationDate)
    {
        return new(expirationDate);
    }
}

