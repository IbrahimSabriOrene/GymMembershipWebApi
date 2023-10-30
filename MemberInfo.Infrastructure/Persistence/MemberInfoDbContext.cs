using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Customer.Infrastructure.Persistence
{
    public class MemberInfoDbContext
    {
        private readonly IConfiguration _config;

        public MemberInfoDbContext(IConfiguration config)
        {
            _config = config;
        }



    }



}