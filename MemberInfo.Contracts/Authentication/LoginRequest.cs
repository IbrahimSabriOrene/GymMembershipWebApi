using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Contracts.Authentication;

public record LoginRequest
(
    string Email,
    string Password
);
