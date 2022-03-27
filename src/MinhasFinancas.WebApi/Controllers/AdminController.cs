using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.Interfaces;

namespace MinhasFinancas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminAppService _adminAppService;
        public AdminController(IAdminAppService adminAppService)
        {
            _adminAppService = adminAppService;
        }

    }
}
