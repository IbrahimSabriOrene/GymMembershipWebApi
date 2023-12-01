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
    DateTime ExpirationDate, 
    ProductId ProductId


);

public record ProductId(Guid Value); // This will be flat value in the database like ProductId = 00000000-0000-0000-0000-000000000000

public record CustomerId(Guid Value); // This will be flat value in the database like CustomerId = 00000000-0000-0000-0000-000000000000