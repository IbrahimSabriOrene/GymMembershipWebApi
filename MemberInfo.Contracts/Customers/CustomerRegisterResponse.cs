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
    DateTime CreationDate,
    DateTime? LastUpdateDate,
    //Expiration date -> Come from product
    DateTime ExpirationDate, //Not sure about this one, maybe date time.
    ProductId ProductId // Product Id can may be a guid


);

public record ProductId(Guid Value);

public record CustomerId(Guid Value); //Change this to direct Guid Value.