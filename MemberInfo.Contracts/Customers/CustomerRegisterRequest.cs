using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Contracts.Customers
{
    public record CustomerRegisterRequest
(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    Guid ProductId // Product Id can may be a guid
    //Make this another record for ProductId

);
}

