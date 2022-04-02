using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.Interfaces;
using MinhasFinancas.Application.ViewModels.Category;

namespace MinhasFinancas.WebApi.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;
        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }


        /// <summary>
        /// Metodo para criar uma Categoria
        /// </summary>
        /// <param name="categoryViewModel">Dados necessarios para criação da categoria</param>
        /// <returns>Retorna  status de sucesso ou falha</returns>
        [Produces("application/json")]
        [HttpPost("CreateCategory")]
        [ProducesResponseTypeAttribute(StatusCodes.Status200OK)]
        [ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest)]
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

        [Produces("application/json")]
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

        [Produces("application/json")]
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory([FromQuery] int Id)
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

        [Produces("application/json")]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int Id)
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

        [Produces("application/json")]
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllUserCategories()
        {
            return Ok(await _categoryAppService.ListUserCategories());
        }

        [Produces("application/json")]
        [HttpGet("GetEntryCategories")]
        public async Task<IActionResult> GetUserEntryCategories()
        {
            return Ok(await _categoryAppService.ListUserEntryCategories());
        }

        [Produces("application/json")]
        [HttpGet("GetOutputCategories")]
        public async Task<IActionResult> GetUserOutputCategories()
        {
            return Ok(await _categoryAppService.ListUserOutputCategories());
        }
    }
}
