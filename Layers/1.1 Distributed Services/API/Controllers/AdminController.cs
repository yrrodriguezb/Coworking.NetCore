using System.Threading.Tasks;
using Coworking.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Coworking.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _AdminService;
        public AdminController(IAdminService adminService)
        {
            _AdminService = adminService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var name = await _AdminService.GetAdminName(id);
            return Ok(name);
        }

    }
}