using System.Globalization;
using Customer.Domain.Common.Interfaces.Persistence;
using Customer.Domain.Models;
using Customer.Domain.Person.ValueObjects;
using Customer.Domain.Products;
using Customer.Domain.Products.ValueObjects;

namespace Customer.Domain.Person;

public sealed class Person : AggregateRoot<PersonId>
{
    private readonly IProductRepository _productRepository;

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public DateTime? CreationDate { get; private set; }
    public DateTime? LastUpdateDate { get; private set; }
    public DateTime? ExpirationDate { get; private set; }
    public ProductId ProductId { get; private set; }
    public IProductRepository ProductRepository { get; private set; } = null!;

    public Person(
        PersonId personId,
        string firstName,
        string lastName,
        string email,
        string phoneNumber,
        DateTime creationDate,
        DateTime? lastUpdateDate,
        DateTime? expirationDate,
        ProductId productId,
        IProductRepository productRepository

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
        _productRepository = productRepository;

    }

    public DateTime? UpdateExpirationDate(DateTime date)
    {
        Product? product = _productRepository.FindById(ProductId);
        DateTime? expirationDate = product?.GetExpirationDate(date);
        this.ExpirationDate = expirationDate;

        return this.ExpirationDate;

    }

    public static Person Create(
        string firstName,
        string lastName,
        string email,
        string phoneNumber,
        ProductId productId,
        IProductRepository productRepository)
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
            productId: productId,
            productRepository: productRepository
            );

        person.UpdateExpirationDate(DateTime.UtcNow); //This is not valid way to do this. May not work


        return person;
    }

    // We can make it like a choice of months. 1 through 12.
    // There is a problem about this.






}