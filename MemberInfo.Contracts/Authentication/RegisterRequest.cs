using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Contracts.Authentication;

public record RegisterRequest
(
    string Email,
    string Password,
    string FirstName,
    string LastName
);
