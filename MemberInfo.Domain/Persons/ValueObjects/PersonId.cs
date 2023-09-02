using MemberInfo.Domain.Models;

namespace MemberInfo.Domain.Person.ValueObjects;

public sealed class PersonId : ValueObject
{
    public Guid Value { get ;}
    
    public PersonId(Guid value)
    {
        Value = value;
    }

    public static PersonId CreateUnique(){
        
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
