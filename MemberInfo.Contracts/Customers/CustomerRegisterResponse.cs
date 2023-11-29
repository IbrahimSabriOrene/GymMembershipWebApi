using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Contracts.Customers;

public record CustomerRegisterResponse
(
    CustomerId CustomerId,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    //Expiration date -> Come from product
    string ExpirationDate, //Not sure about this one, maybe date time.
    ProductId ProductId // Product Id can may be a guid


);

public record ProductId(Guid Value);

public record CustomerId(Guid Value);