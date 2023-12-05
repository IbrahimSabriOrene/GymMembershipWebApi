using Microsoft.Data.SqlClient;
namespace MemberInfo.Domain.Common.Interfaces.Services
{
    public interface IDbContext
    {
        Task<T> GetAsync<T>(string sql, object parameters);
        Task<bool> EditDataAsync(string sql, object parameters);


    }
}
