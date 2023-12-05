using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Customer.Domain.Person;
using Customer.Domain.Person.ValueObjects;
using MemberInfo.Domain.Common.Interfaces.Persistence;
using Customer.Domain.Products.ValueObjects;

namespace Customer.Infrastructure.Persistence
{

    public class CustomerRepository : ICustomerRepository
    {
        private static readonly List<Domain.Person.Customer> _person = new();
        private readonly IConfiguration _config;

        public CustomerRepository(IConfiguration config)
        {
            _config = config;
        }

        public void Add(Domain.Person.Customer person)
        {
            _person.Add(person);
        }

        public Domain.Person.Customer? FindById(PersonId personId)
        {
            if (personId is null)
            {
                return null;
            }
            return _person.FirstOrDefault(p => p.Id == personId);
        }
    }



}