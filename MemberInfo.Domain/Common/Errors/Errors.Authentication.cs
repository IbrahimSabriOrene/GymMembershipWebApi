using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;

namespace Customer.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Conflict(
            code: "Authentication.InvalidCred",
            description: "The credentials provided are invalid.");

        public static Error InvalidToken => Error.Conflict(
            code: "Authentication.InvalidToken",
            description: "The token provided is invalid.");

        
    }
}
