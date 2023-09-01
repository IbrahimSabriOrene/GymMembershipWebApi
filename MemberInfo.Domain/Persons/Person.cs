using MemberInfo.Domain.Common.Interfaces.Persistence;
using MemberInfo.Domain.Models;
using MemberInfo.Domain.Person.ValueObjects;
using MemberInfo.Domain.Products;
using MemberInfo.Domain.Products.ValueObjects;

namespace MemberInfo.Domain.Person;

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
    public IProductRepository productRepository1 { get; private set; } = null!;

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
    


    public static Person Create(
        string firstName,
        string lastName,
        string email,
        string phoneNumber,
        DateTime? expirationDate,
        ProductId productId,
        IProductRepository productRepository)
    {
        var personId = PersonId.CreateUnique(Guid.NewGuid()); // We are creating the guid id in here this is not good 
        var person = new Person(
            personId: personId,
            firstName: firstName,
            lastName: lastName,
            email: email,
            phoneNumber: phoneNumber,
            creationDate: DateTime.UtcNow,
            lastUpdateDate: DateTime.UtcNow,
            expirationDate: expirationDate,
            productId: productId,
            productRepository: productRepository
            );

            person.UpdateExpirationDate();
        

        return person;
    }
     public void UpdateExpirationDate() 
    {
        Product product = _productRepository.FindById(ProductId);
        DateTime expirationDate = product.GetExpirationDate();
        this.ExpirationDate = expirationDate;

    }

    


    
}