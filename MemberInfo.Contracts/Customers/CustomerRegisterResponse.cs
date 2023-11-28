using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Contracts.Customers;

public record CustomerRegisterResponse
(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    //Expiration date -> Come from product
    string ExpirationDate, //Not sure about this one, maybe date time.
    Guid ProductId // Product Id can may be a guid


);