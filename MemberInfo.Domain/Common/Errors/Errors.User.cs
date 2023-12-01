using ErrorOr;

namespace Customer.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Email already exists");

        public static Error UserNotFound(string description)
        {
            return Error.NotFound(
                code: "User.NotFound",
                description: description);
        }

        public static Error InvalidCredentials => Error.Conflict(
            code: "User.InvalidCred",
            description: "The credentials provided are invalid.");
        
    }

}

