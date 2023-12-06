using Customer.Domain.Person;
using ErrorOr;
using MediatR;

namespace MemberInfo.Application.Customers.Commands;


public record CreateCustomerCommand(

    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    Guid ProductId
) : IRequest<ErrorOr<Customer.Domain.Person.Customer>>;

//Add PersonId here.






