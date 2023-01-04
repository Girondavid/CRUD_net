using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApp.UserServices.Infrastructure.DTO
{
    public class UserDTO
    {
        public string Email { get; }
        public string Password { get; }

        public UserDTO(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}