using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Api.Data;
using Portal.Api.Dtos;
using Portal.Api.Models;

namespace Portal.Api.Controllers
{    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;

        public AuthController(IAuthRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegister)
        {
            userForRegister.Username = userForRegister.Username.ToLower();

            if(await _repository.UserExists(userForRegister.Username))
                return BadRequest("Użytkownik o takiej nazwie już istnieje!");

            var userToCreate = new User
            {
                Username = userForRegister.Username
            };

            var createdUser  = await _repository.Register(userToCreate, userForRegister.Password);

            return StatusCode(201);
        }
    }
}