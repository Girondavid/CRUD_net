using CrudApp.UserServices.Domain.Encriptation;
using CrudApp.UserServices.Domain.UserRepository;
using CrudApp.UserServices.Domain.UserRepository.ContractServices;
using CrudApp.UserServices.Infrastructure.CustomException;

namespace CrudApp.UserServices.Infrastructure.Repository
{
    public class SingInService : ISingInService
    {
        private readonly ISingIn _signIn;
        private readonly IEmailValidator _emailValidator;

        public SingInService(ISingIn singIn, IEmailValidator emailValidator){
            this._emailValidator = emailValidator;
            this._signIn = singIn;
        }
        public async Task<int?> accessTheAccount(string email, string password)
        {
            string passwordEncripted = new Encripter().Encrypt(password);
            int? isExistAccount = await this._signIn.login(email, passwordEncripted);
            if(isExistAccount == null){
                throw new HttpResponseException(404, new { message = "invalid email or password, check it out"});
            }
            return isExistAccount;
        }
    }
}