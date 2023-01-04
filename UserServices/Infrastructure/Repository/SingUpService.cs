using CrudApp.UserServices.Domain;
using CrudApp.UserServices.Domain.Encriptation;
using CrudApp.UserServices.Domain.UserRepository;
using CrudApp.UserServices.Domain.UserRepository.ContractServices;
using CrudApp.UserServices.Infrastructure.CustomException;

namespace CrudApp.UserServices.Infrastructure.Repository
{
    public class SingUpService : ISingUpService
    {
        private readonly ISingUp _register;
        private readonly IEmailValidator _emailValidator;

        public SingUpService(ISingUp register, IEmailValidator emailValidator){
            this._register = register;
            this._emailValidator = emailValidator;
        }
        public async Task newUser(string email, string password){
            Boolean isEmail = await this._emailValidator.existingEmail(email);
            if(isEmail){
                throw new HttpResponseException(400, new { message = "Existing email" });
            }
            UserEntity userEntity = new UserEntity(email, password);
            string passwordEncripted = new Encripter().Encrypt(password);

            await this._register.RegisterUser(email, passwordEncripted);
        }
    }
}