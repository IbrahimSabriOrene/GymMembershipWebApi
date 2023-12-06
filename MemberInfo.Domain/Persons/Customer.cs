using Customer.Domain.Models;
using Customer.Domain.Person.ValueObjects;
using Customer.Domain.Persons.ValueObjects;
using Customer.Domain.Products.ValueObjects;

namespace Customer.Domain.Person
{
    public sealed class Customer : AggregateRoot<PersonId>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime? CreationDate { get; private set; }
        public DateTime? LastUpdateDate { get; private set; }
        public Expiration? Expiration { get; private set; }
        public ProductId ProductId { get; private set; }

        public Customer(
            PersonId personId,
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            DateTime creationDate,
            DateTime? lastUpdateDate,
            Expiration? expiration,
            ProductId productId
        ) : base(personId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            CreationDate = creationDate;
            LastUpdateDate = lastUpdateDate;
            Expiration = expiration;
            ProductId = productId;
        }

        public static Customer Create(
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            ProductId productId,
            Expiration? expirationDate)
        {

            var personId = PersonId.CreateUnique(); // We are creating the guid id in here this is not good 
            var person = new Customer(
                personId: personId,
                firstName: firstName,
                lastName: lastName,
                email: email,
                phoneNumber: phoneNumber,
                creationDate: DateTime.UtcNow, // This should be change.
                lastUpdateDate: DateTime.UtcNow,
                expiration: expirationDate,   
                productId: productId
            );

            return person;
        }
    }
}
