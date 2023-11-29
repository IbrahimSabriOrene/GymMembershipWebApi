using System.Globalization;
using Customer.Domain.Common.Interfaces.Persistence;
using Customer.Domain.Models;
using Customer.Domain.Person.ValueObjects;
using Customer.Domain.Products;
using Customer.Domain.Products.ValueObjects;

namespace Customer.Domain.Person;

public sealed class Person : AggregateRoot<PersonId>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public DateTime? CreationDate { get; private set; }
    public DateTime? LastUpdateDate { get; private set; }
    public DateTime? ExpirationDate { get; private set; }
    public ProductId ProductId { get; private set; }

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
        ProductId productId)
    {


        var personId = PersonId.CreateUnique(); // We are creating the guid id in here this is not good 
        var person = new Person(
            personId: personId,
            firstName: firstName,
            lastName: lastName,
            email: email,
            phoneNumber: phoneNumber,
            creationDate: DateTime.UtcNow, // This should be change.
            lastUpdateDate: DateTime.UtcNow,
            expirationDate: null,
            productId: productId
            );


        return person;
    }
    // We can make it like a choice of months. 1 through 12.
    // There is a problem about this.






}