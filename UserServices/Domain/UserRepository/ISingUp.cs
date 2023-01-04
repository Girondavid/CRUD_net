namespace CrudApp.UserServices.Domain.UserRepository
{
    public interface ISingUp
    {
        public Task RegisterUser(string email, string password);
    }
}