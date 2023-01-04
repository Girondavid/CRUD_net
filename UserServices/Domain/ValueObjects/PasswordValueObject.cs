using System.Text.RegularExpressions;
using CrudApp.UserServices.Infrastructure.CustomException;

namespace CrudApp.UserServices.Domain.ValueObjects
{
    public class PasswordValueObject
    {
        private string _password;

        public PasswordValueObject(string password){
            _password = password;
        }   

        public string ValidationPassword()
        {
            string pattern = "^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)[A-Za-z\\d]{8,}$";
            if(!Regex.IsMatch(this._password, pattern)){
                throw new HttpResponseException(422, new { message = "The password must be at least 8 character with one uppercase"});
            }
            return this._password;
        }
    }
}