using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using MemberInfo.Domain.Entities;

namespace MemberInfo.Domain.Common.Errors;

public  static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Email already exists");
    }
    
}
