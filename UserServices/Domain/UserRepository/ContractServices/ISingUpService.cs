using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApp.UserServices.Domain.UserRepository.ContractServices
{
    public interface ISingUpService
    {
        public Task newUser(string email, string password);
    }
}