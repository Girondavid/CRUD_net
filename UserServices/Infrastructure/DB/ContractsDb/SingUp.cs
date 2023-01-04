using CrudApp.UserServices.Domain.UserRepository;

namespace CrudApp.UserServices.Infrastructure.DB.ContractsDb
{
    public class SingUp : ISingUp
    {
        private NominasContext _context;

        public SingUp(NominasContext context){
            this._context = context;
        }

        public async Task RegisterUser(string email, string password)
        {
            User user = new User();
            user.Email = email;
            user.Password = password;

            this._context.Add(user);
            await this._context.SaveChangesAsync();
        }
    }
}