using Customer.Contracts.Customers;
using Customer.Domain.Person;
using Customer.Domain.Person.ValueObjects;
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
        .Map(dest => dest.Email, src => src.Email);


        config.NewConfig<Person, CustomerRegisterResponse>();

    }
}


