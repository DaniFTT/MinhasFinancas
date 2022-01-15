using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.Interfaces;
using MinhasFinancas.Application.ViewModels;
using MinhasFinancas.Application.ViewModels.User;
using MinhasFinancas.Domain.Entities;
using System.Security.Claims;

namespace MinhasFinancas.WebApi.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel login)
        {
            if(ModelState.IsValid)
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
