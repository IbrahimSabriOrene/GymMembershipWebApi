using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Domain.Person;
using Customer.Domain.Person.ValueObjects;
using Customer.Domain.Products.ValueObjects;

namespace MemberInfo.Domain.Common.Interfaces.Persistence;

public interface ICustomerRepository
{
    void Add(Customer.Domain.Person.Customer person);
    Customer.Domain.Person.Customer? FindById(PersonId personId);
    
    }