using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.DTOs.AuthenticationDTOs.Request;
using MinhasFinancas.Application.Interfaces;

namespace MinhasFinancas.WebApi.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]/")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class AuthenticationController : ControllerBase
    {
        private readonly IIdentityAppService _identityAppService;
        public AuthenticationController(IIdentityAppService identityAppService)
        {
            _identityAppService = identityAppService;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userLoginRequest)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _identityAppService.Login(userLoginRequest);
                
                if (loginResult.Success)
                    return Ok(loginResult);
                else if (loginResult.IsInvalidResponse())
                    return BadRequest(loginResult);

                return Unauthorized(loginResult);
            }


            return BadRequest("Tentativa de Login Inválida");
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest userRegisterRequest)
        {
            if (ModelState.IsValid)
            {
                var registerResult = await _identityAppService.Register(userRegisterRequest);

                if (registerResult.Success)
                    return Ok(registerResult);
                else if (registerResult.IsInvalidResponse())
                    return BadRequest(registerResult);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return BadRequest("Tentativa de Registro Inválida");
        }
    }
}
