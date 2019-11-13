using System.Collections.Generic;
using System.Threading.Tasks;
using Coworking.API.Mappers;
using Coworking.API.ViewModels;
using Coworking.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Coworking.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService _officeService;
        public OfficeController(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        /// <summary>
        /// GET all Office
        /// </summary>
        /// <returns>Office Collection</returns>
        [HttpGet]
        [Produces("application/json", Type = typeof(List<OfficeModel>))]
        public async Task<IActionResult> GetAll()
        {
            var offices = await _officeService.GetAllOffices();
            return Ok(offices);
        }

        /// <summary>
        /// GET a Office
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Office</returns>
        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(OfficeModel))]
        public async Task<IActionResult> Get(int id)
        {
            var office = await _officeService.GetOffice(id);
            return Ok(office);
        }

        /// <summary>
        /// Add a new office
        /// </summary>
        /// <param name="office"></param>
        /// <returns>Office</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(401)]
        [Produces("application/json", Type = typeof(OfficeModel))]
        [HttpPost]
        public async Task<IActionResult> AddOffice([FromBody] OfficeModel Office)
        {
            var newOffice = await _officeService.AddOffice(OfficeMapper.Map(Office));
            return Ok(newOffice);
        }

        /// <summary>
        /// Delete a Office
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        [HttpDelete("{id}")]
        [Produces("application/json", Type = typeof(bool))]
        public async Task<IActionResult> DeleteOffice(int id)
        {
            await _officeService.DeleteOffice(id);
            return Ok();
        }

        /// <summary>
        /// Update a Office
        /// </summary>
        /// <param name="Office"></param>
        /// <returns>Office</returns>
        [HttpPut]
        [Produces("application/json", Type = typeof(OfficeModel))]
        public async Task<IActionResult> UpdateOffice([FromBody]OfficeModel Office)
        {
            var updatedOffice = await _officeService.UpdateOffice(OfficeMapper.Map(Office));
            return Ok(updatedOffice);
        }

    }
}