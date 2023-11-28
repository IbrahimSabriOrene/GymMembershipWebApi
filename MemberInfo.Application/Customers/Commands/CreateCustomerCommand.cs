using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Domain.Person;
using Customer.Domain.Person.ValueObjects;
using ErrorOr;
using MediatR;

namespace MemberInfo.Application.Customers.Commands;


public record CreateCustomerCommand(

    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    DateTime CreationDate,
    DateTime? LastUpdateDate,
    DateTime? ExpirationDate,
    ProductIdCommand ProductId
) : IRequest<ErrorOr<Person>>;

//Add PersonId here.
public record ProductIdCommand(
    Guid Id

);




