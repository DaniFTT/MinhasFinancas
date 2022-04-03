using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.Interfaces;
using MinhasFinancas.Application.ViewModels.Category;
using MinhasFinancas.Infra.Identity.Constants;

namespace MinhasFinancas.WebApi.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.UserApp)]
    [Route("api/[controller]/")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;
        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateUpdateCategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok(await _categoryAppService.Add(categoryViewModel));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            return BadRequest("Erro ao adicionar Categoria. Verique os campos preenchidos.");
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] CreateUpdateCategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok(await _categoryAppService.Update(categoryViewModel));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            return BadRequest("Erro ao atualizar Categoria. Verique os campos preenchidos.");
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory([FromQuery] Guid Id)
        {
            try
            {
                return Ok(await _categoryAppService.Delete(Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                var cat = await _categoryAppService.GetById(Id);
                return Ok(cat);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("GetAllUserCategories")]
        public async Task<IActionResult> GetAllUserCategories()
        {
            return Ok(await _categoryAppService.ListUserCategories());
        }

        [HttpGet("GetUserEntryCategories")]
        public async Task<IActionResult> GetUserEntryCategories()
        {
            return Ok(await _categoryAppService.ListUserEntryCategories());
        }

        [HttpGet("GetUserOutputCategories")]
        public async Task<IActionResult> GetUserOutputCategories()
        {
            return Ok(await _categoryAppService.ListUserOutputCategories());
        }
    }
}
