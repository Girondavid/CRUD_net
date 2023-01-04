using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApp.UserServices.Domain.UserRepository.ContractServices
{
    public interface ISingInService
    {
        public Task<int?> accessTheAccount(string email, string password);
    }
}