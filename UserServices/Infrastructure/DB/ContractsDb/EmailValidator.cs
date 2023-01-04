using CrudApp.UserServices.Domain.UserRepository;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.UserServices.Infrastructure.DB.ContractsDb
{
    public class EmailValidator : IEmailValidator
    {
        private readonly NominasContext _context;

        public EmailValidator(NominasContext context){
            this._context = context;
        }

        public async Task<bool> existingEmail(string email)
        {
            var user = await this._context.Users.FirstOrDefaultAsync(
            user => user.Email == email
            );
            if (user == null)
            {
                return false;
            }

            return true;
        }
    }
}