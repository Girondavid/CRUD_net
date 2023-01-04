using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using CrudApp.UserServices.Domain.UserRepository.ContractServices;
using CrudApp.UserServices.Infrastructure.CustomException;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using CrudApp.UserServices.Infrastructure.DTO;

namespace CrudApp.UserServices.Infrastructure.Controller
{
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISingUpService _singUp;

        private readonly ISingInService _singIn;

        public UserController(IConfiguration configuration, ISingUpService singUp, ISingInService singIn){
            this._configuration = configuration;
            this._singIn = singIn;
            this._singUp = singUp;
        }

        [Route("api/signup")]
        [HttpPost]
        public async Task<IActionResult> newUser([FromBody] UserDTO user){
            try
            {
                await this._singUp.newUser(user.Email, user.Password);
                return StatusCode(201, new {message = "User created"});
            }
            catch (HttpResponseException exception)
            {
                return StatusCode(exception.StatusCode, exception.Value);
            }
            catch (Exception exception)
            {
                return StatusCode(500, new { message = exception.Message });
            }
        }

         [Route("api/signin")]
        [HttpPost]
        public async Task<IActionResult> login([FromBody] UserDTO user){
            try
            {
                int? userId = await this._singIn.accessTheAccount(user.Email, user.Password);

                string Tokens = GenerateJSONWebToken( userId ?? 0);

                return StatusCode(201, new { token = Tokens });
            }
            catch (HttpResponseException exception)
            {
                return StatusCode(exception.StatusCode, exception.Value);
            }
            catch (Exception exception)
            {
                return StatusCode(500, new { message = exception.Message });
            }
        }
        private string GenerateJSONWebToken(int userId)
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(this._configuration["Jwt:Key"])
            );

            var credentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256
            );

            var claims = new[] {
                new Claim("userId", userId.ToString())
            };

            var token = new JwtSecurityToken(
                this._configuration["Jwt:Issuer"],
                this._configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}