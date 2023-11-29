using Customer.Contracts.Customers;
using Customer.Domain.Person;
using Customer.Domain.Person.ValueObjects;
using Customer.Domain.Persons.ValueObjects;
using Mapster;
using MemberInfo.Application.Customers.Commands;
namespace Customer.Api.Common.Mapping;

public class CustomerMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PersonId, CustomerId>()
        .Map(dest => dest.Value, src => src.Value);
        config.NewConfig<CustomerRegisterRequest, CreateCustomerCommand>()
        .Map(dest => dest.FirstName, src => src.FirstName)
        .Map(dest => dest.LastName, src => src.LastName)
        .Map(dest => dest.Email, src => src.Email)
        .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
        .Map(dest => dest.Value, src => src.Value);
        config.NewConfig<Person, CustomerRegisterResponse>()
        .Map(dest => dest.CustomerId, src => src.Id.Value)
        .Map(dest => dest.ProductId.Value, src => src.ProductId.Value)
        .Map(dest => dest.FirstName, src => src.FirstName)
        .Map(dest => dest.LastName, src => src.LastName)
        .Map(dest => dest.Email, src => src.Email)
        .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
        .Map(dest => dest.CreationDate, src => src.CreationDate)
        .Map(dest => dest.LastUpdateDate, src => src.LastUpdateDate)
        .Map(dest => dest.ExpirationDate, src => src.Expiration);
        config.NewConfig<Expiration, DateTime>()
        .MapWith(expiration => expiration._expirationDate);


        // Map Person's Id to CustomerRegisterResponse's CustomerId;

    }
}


