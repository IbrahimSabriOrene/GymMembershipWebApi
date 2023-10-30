using Customer.Domain.Models;

namespace Customer.Domain.Person.ValueObjects;

public sealed class PersonId : ValueObject
{
    public Guid Value { get; private set; }

    public PersonId(Guid value)
    {
        Value = value;
    }

    public static PersonId CreateUnique()
    {

        return new PersonId(Guid.NewGuid());

    }

    public static PersonId Create(Guid value)
    {
        return new PersonId(value);
    }


    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
