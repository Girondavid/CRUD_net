using CrudApp.UserServices.Domain.UserRepository;
using Microsoft.EntityFrameworkCore;


namespace CrudApp.UserServices.Infrastructure.DB.ContractsDb
{
    public class SingIn : ISingIn
    {
        private NominasContext _context;

        public SingIn(NominasContext context){
            this._context = context;
        }
        public async Task<int?> login(string email, string password)
        {
            var user = await this._context.Users.FirstOrDefaultAsync(user =>
            user.Email == email && user.Password == password);
            
            return user?.UserId;
        }
    }
}