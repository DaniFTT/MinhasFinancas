using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.DTOs.AuthenticationDTOs.Request;
using MinhasFinancas.Application.Interfaces;

namespace MinhasFinancas.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IIdentityAppService _identityAppService;
        public AuthenticationController(IIdentityAppService identityAppService)
        {
            _identityAppService = identityAppService;
        }


        [HttpPost("Login")]
        [Produces("application/json")]
        [ProducesResponseTypeAttribute(StatusCodes.Status200OK)]
        [ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest)]
        [ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userLoginRequest)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _identityAppService.Login(userLoginRequest);
                
                if (loginResult.Success)
                    return Ok(loginResult);

                return Unauthorized(loginResult);
            }


            return BadRequest("Tentativa de Login Inválida");
        }


        [HttpPost("Register")]
        [Produces("application/json")]
        [ProducesResponseTypeAttribute(StatusCodes.Status200OK)]
        [ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest)]
        [ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest userRegisterRequest)
        {
            if (ModelState.IsValid)
            {
                var registerResult = await _identityAppService.Register(userRegisterRequest);

                if (registerResult.Success)
                    return Ok(registerResult);
                else if (registerResult.Errors.Any())
                    return BadRequest(registerResult);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }


            return BadRequest("Tentativa de Registro Invalida");
        }
    }
}
