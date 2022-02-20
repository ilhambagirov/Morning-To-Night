using M2N.Application.DTOs;
using M2N.Application.Modules.AccountModule;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace M2N.API.Controllers
{
    public class AccountController : BaseApiController
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginCreds)
        {
            var response = await mediatr.Send(new UserLoginCommand { LoginDto = loginCreds });
            if (response == null) return NotFound();
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerCreds)
        {
            var response = await mediatr.Send(new UserRegisterCommand { RegisterDtoProperty = registerCreds });
            if (response == null) return ValidationProblem(); ;
            return Ok(response);
        }
    }
}
