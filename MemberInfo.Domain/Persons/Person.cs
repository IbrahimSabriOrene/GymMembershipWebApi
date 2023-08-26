using MemberInfo.Domain.Models;
using MemberInfo.Domain.Person.ValueObjects;
using MemberInfo.Domain.Products;
using MemberInfo.Domain.Products.ValueObjects;

namespace MemberInfo.Domain.Person;

public sealed class Person : AggregateRoot<PersonId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string PhoneNumber { get; }
    public DateTime? CreationDate { get; }
    public DateTime? LastUpdateDate { get; }
    public DateTime? ExpirationDate { get; }
    public ProductId ProductId { get; }

    public Person(
        PersonId personId,
        string firstName,
        string lastName,
        string email,
        string phoneNumber,
        DateTime creationDate,
        DateTime? lastUpdateDate,
        DateTime? expirationDate,
        ProductId productId
       
       ) : base(personId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        CreationDate = creationDate;
        LastUpdateDate = lastUpdateDate;
        ExpirationDate = expirationDate;
        ProductId = productId;
        
    }
  

    public static Person Create(
        string firstName,
        string lastName,
        string email,
        string phoneNumber,
        DateTime? expirationDate,
        ProductId productId)
    {
        var personId = PersonId.CreateUnique(Guid.NewGuid()); // We are creating the guid id in here this is not good 
        return new Person(
            personId: personId,
            firstName: firstName,
            lastName: lastName,
            email: email,
            phoneNumber: phoneNumber,
            creationDate: DateTime.UtcNow,
            lastUpdateDate: DateTime.UtcNow,
            expirationDate: expirationDate,
            productId: productId
            );
    }



    
}

// POST /api/v1/Persons/PersonId

// we must find a way to make persons and product share same status
// okay i found the way, remove status from products, and add it to person
// also remove expiration date from product and add it to person
// this way we can make sure that only the person has the expiration instead of package,
// by doing that we can have a lot of persons with same product, but different expiration date
// how to get the expiration date of the product?