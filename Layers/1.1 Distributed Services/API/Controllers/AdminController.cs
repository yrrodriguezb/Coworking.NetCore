using System.Collections.Generic;
using System.Threading.Tasks;
using Coworking.API.Mappers;
using Coworking.API.ViewModels;
using Coworking.Application.Configuration;
using Coworking.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Coworking.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IAppConfig _config;

        public AdminController(IAdminService adminService, IAppConfig config)
        {
            _adminService = adminService;
            _config = config;
        }

        /// <summary>
        /// GET all Admin
        /// </summary>
        /// <returns>Admin Collection</returns>
        [HttpGet]
        [Produces("application/json", Type = typeof(List<AdminModel>))]
        public async Task<IActionResult> GetAll()
        {
            var admins = await _adminService.GetAllAdmins();
            return Ok(admins);
        }

        /// <summary>
        /// GET a Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Admin</returns>
        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(AdminModel))]
        public async Task<IActionResult> Get(int id)
        {
            var max = _config.MaxTrys;
            var seconds = _config.SecondsToWait;

            var admin = await _adminService.GetAdmin(id);
            return Ok(admin);
        }

        /// <summary>
        /// Add a new admin
        /// </summary>
        /// <param name="admin"></param>
        /// <returns>Admin</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(401)]
        [Produces("application/json", Type = typeof(AdminModel))]
        [HttpPost]
        public async Task<IActionResult> AddAdmin([FromBody] AdminModel admin)
        {
            var newAdmin = await _adminService.AddAdmin(AdminMapper.Map(admin));
            return Ok(newAdmin);
        }

        /// <summary>
        /// Delete a admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        [HttpDelete("{id}")]
        [Produces("application/json", Type = typeof(bool))]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            await _adminService.DeleteAdmin(id);
            return Ok();
        }

        /// <summary>
        /// Update a admin
        /// </summary>
        /// <param name="admin"></param>
        /// <returns>Admin</returns>
        [HttpPut]
        [Produces("application/json", Type = typeof(AdminModel))]
        public async Task<IActionResult> UpdateAdmin([FromBody]AdminModel admin)
        {
            var updatedAdmin = await _adminService.UpdateAdmin(AdminMapper.Map(admin));
            return Ok(updatedAdmin);
        }

    }
}