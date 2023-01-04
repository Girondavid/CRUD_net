using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApp.UserServices.Domain.UserRepository
{
    public interface ISingIn
    {
        public Task<int?> login(string email, string password);
    }
}