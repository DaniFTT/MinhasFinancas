using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.DTOs.AdminDTOs.Request;
using MinhasFinancas.Application.DTOs.AdminDTOs.Response;
using MinhasFinancas.Application.Interfaces;
using MinhasFinancas.Infra.Identity.Constants;

namespace MinhasFinancas.WebApi.Controllers
{

    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
    [Route("api/[controller]/")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class AdminController : ControllerBase
    {
        private readonly IAdminAppService _adminAppService;
        public AdminController(IAdminAppService adminAppService)
        {
            _adminAppService = adminAppService;
        }

        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = await _adminAppService.GetAllRoles();

            if (result.Success)
                return Ok(result);
            else if (result.IsInvalidResponse())
                return BadRequest(result);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (ModelState.IsValid)
            {
                var result = await _adminAppService.CreateRole(roleName);

                if (result.Success)
                    return Ok(result);
                else if (result.IsInvalidResponse())
                    return BadRequest(result);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return BadRequest("Erro na requisição!");
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _adminAppService.GetAllUsers();

            if (result.Success)
                return Ok(result);
            else if (result.IsInvalidResponse())
                return BadRequest(result);

            return BadRequest("Erro na requisição!");
        }

        [HttpGet("GetUserRoles")]
        public async Task<IActionResult> GetUserRoles(string userEmail)
        {
            var result = await _adminAppService.GetUserRoles(userEmail);

            if (result.Success)
                return Ok(result);
            else if (result.IsInvalidResponse())
                return BadRequest(result);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("AddUserToRole")]
        public async Task<IActionResult> AddUserToRole([FromBody] AddUserToRoleRequest addUserToRoleRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _adminAppService.AddUserToRole(addUserToRoleRequest);

                if (result.Success)
                    return Ok(result);
                else if (result.IsInvalidResponse())
                    return BadRequest(result);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return BadRequest("Erro na requisição!");
        }

        [HttpDelete("RemoveUserFromRole")]
        public async Task<IActionResult> RemoveUserFromRole([FromBody] RemoveUserFromRoleRequest removeUserFromRoleRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _adminAppService.RemoveUserFromRole(removeUserFromRoleRequest);

                if (result.Success)
                    return Ok(result);
                else if (result.IsInvalidResponse())
                    return BadRequest(result);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return BadRequest("Erro na requisição!");
        }


        [HttpGet("GetAllClaims")]
        public async Task<IActionResult> GetAllClaims(string email)
        {
            var result = await _adminAppService.GetAllClaims(email);

            if (result.Success)
                return Ok(result);
            else if (result.IsInvalidResponse())
                return BadRequest(result);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("AddClaimsToUser")]
        public async Task<IActionResult> AddClaimsToUser([FromBody] AddClaimsToUserRequest addClaimsToUserRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _adminAppService.AddClaimsToUser(addClaimsToUserRequest);

                if (result.Success)
                    return Ok(result);
                else if (result.IsInvalidResponse())
                    return BadRequest(result);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return BadRequest("Erro na requisição!");
        }
    }
}
