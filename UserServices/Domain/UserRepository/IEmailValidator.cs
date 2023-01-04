namespace CrudApp.UserServices.Domain.UserRepository
{
    public interface IEmailValidator
    {
        public Task<Boolean> existingEmail(string email);
    }
}