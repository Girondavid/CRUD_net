using CrudApp.UserServices.Domain.ValueObjects;

namespace CrudApp.UserServices.Domain
{
    public class UserEntity
    {
        private string _email;
        private string _password;

        public UserEntity(string email, string password){
            _email = (new EmailValueObject(email)).validationEmail();
            _password = (new PasswordValueObject(password)).ValidationPassword();
        }

        public string email { get {return _email; } }
        public string password {get {return _password; } }
    }
}