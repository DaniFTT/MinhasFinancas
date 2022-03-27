using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.Interfaces;
using MinhasFinancas.Application.ViewModels.User;

namespace MinhasFinancas.WebApi.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationAppService _userAppService;
        public AuthenticationController(IAuthenticationAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel login)
        {
            if (ModelState.IsValid)
                return Ok(await _userAppService.Login(login));

            return BadRequest("Tentativa de Login Invalida");
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel register)
        {
            if (ModelState.IsValid)
                return Ok(await _userAppService.Register(register));

            return BadRequest("Tentativa de Registro Invalida");
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequestViewModel tokenRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _userAppService.RefreshToken(tokenRequest);

                if (result == null)
                {
                    return BadRequest("Invalid tokens");
                }

                return Ok(result);
            }

            return BadRequest("Invalid Paylod");

        }
    }
}
