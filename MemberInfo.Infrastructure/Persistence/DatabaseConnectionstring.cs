using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberInfo.Infrastructure.Persistence
{
    public class DatabaseConnectionstring
    {
        public const string ConnectionStrings = "ConnectionStrings";
        public string DefaultConnection { get; init; } = null!;
    }
}