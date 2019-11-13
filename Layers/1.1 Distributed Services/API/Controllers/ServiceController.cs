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
    public class ServiceController : ControllerBase
    {
        private readonly IServicesService _servicesService;
        public ServiceController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        /// <summary>
        /// GET all Service
        /// </summary>
        /// <returns>Service Collection</returns>
        [HttpGet]
        [Produces("application/json", Type = typeof(List<ServiceModel>))]
        public async Task<IActionResult> GetAll()
        {
            var services = await _servicesService.GetAllServices();
            return Ok(services);
        }

        /// <summary>
        /// GET a Service
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Service</returns>
        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(ServiceModel))]
        public async Task<IActionResult> Get(int id)
        {
            var service = await _servicesService.GetService(id);
            return Ok(service);
        }

        /// <summary>
        /// Add a new service
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Service</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(401)]
        [Produces("application/json", Type = typeof(ServiceModel))]
        [HttpPost]
        public async Task<IActionResult> AddService([FromBody] ServiceModel service)
        {
            var newService = await _servicesService.AddService(ServiceMapper.Map(service));
            return Ok(newService);
        }

        /// <summary>
        /// Delete a service
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        [HttpDelete("{id}")]
        [Produces("application/json", Type = typeof(bool))]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _servicesService.DeleteService(id);
            return Ok();
        }

        /// <summary>
        /// Update a service
        /// </summary>
        /// <param name="admin"></param>
        /// <returns>Service</returns>
        [HttpPut]
        [Produces("application/json", Type = typeof(ServiceModel))]
        public async Task<IActionResult> UpdateService([FromBody]ServiceModel service)
        {
            var updatedService = await _servicesService.UpdateService(ServiceMapper.Map(service));
            return Ok(updatedService);
        }

    }
}