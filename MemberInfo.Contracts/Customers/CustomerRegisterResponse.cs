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
    Guid ProductId


);


<<<<<<< HEAD
public record CustomerId(Guid Value); //Change this to direct Guid Value.
=======
public record CustomerId(Guid Value); // This will be flat value in the database like CustomerId = 00000000-0000-0000-0000-000000000000
>>>>>>> v1.2
