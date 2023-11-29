using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Domain.Person;
using Customer.Domain.Persons.ValueObjects;

namespace MemberInfo.Application.Customers.Common
{
    public record CustomerResult(
        Person Customer);
}