using System.ComponentModel.DataAnnotations;
using CrudApp.UserServices.Infrastructure.CustomException;

namespace CrudApp.UserServices.Domain.ValueObjects
{
    public class EmailValueObject
    {
        private string _email;

        public EmailValueObject(string email){
            _email = email;
        }

        public string validationEmail(){
            if(!new EmailAddressAttribute().IsValid(this._email)){
                throw new HttpResponseException(422, new { message = "Invalid email" });
            }
            return this._email;
        }
    }
}