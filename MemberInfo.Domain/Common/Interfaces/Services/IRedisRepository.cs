using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Domain.Entities;

namespace MemberInfo.Domain.Common.Interfaces.Services
{
    public interface IRedisRepository
    {
        Task<string> GetToken(string email);
        //delete token  
        Task<bool> DeleteToken(string email);
        //store user
    }
}