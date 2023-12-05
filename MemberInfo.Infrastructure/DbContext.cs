using System.Data;
using Microsoft.Data.SqlClient;
using Customer.Domain.Entities;
using Dapper;
using MemberInfo.Domain.Common.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

namespace MemberInfo.Infrastructure
{
    public class DbContext : IDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnectionStringBuilder _builder;
        private readonly IDbConnection _dbConnection;

        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;

            _builder = new SqlConnectionStringBuilder
            {
                DataSource = _configuration["Database:Server"],
                InitialCatalog = _configuration["Database:Database"],
              //  UserID = _configuration["Database:User"],
              //  Password = _configuration["Database:Password"],
                IntegratedSecurity = true,
                MultipleActiveResultSets = true,
                TrustServerCertificate = true

            };

            try
            {
                using var connection = new SqlConnection(_builder.ConnectionString);
                connection.Open();
            }

            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            _dbConnection = new SqlConnection(_builder.ConnectionString);
            _dbConnection.Open();

            
        }
        public async Task<T> GetAsync<T>(string sql, object parameters)
        {
            var result = await _dbConnection.QueryFirstOrDefaultAsync<T>(sql, parameters) ?? throw new Exception("No data found");
            return result;
        }

        public async Task<bool> EditDataAsync(string sql, object parameters)
        {
            var result = await _dbConnection.ExecuteAsync(sql, parameters);
            if (result == 0)
            {
                throw new Exception("No data found"); // TODO: Create custom exception
            }
            return true;
        }

    }


}
