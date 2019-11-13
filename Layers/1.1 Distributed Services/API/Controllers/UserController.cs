using System.Collections.Generic;
using System.Threading.Tasks;
using Coworking.Api.Bussiness.Models;
using Coworking.API.Mappers;
using Coworking.API.ViewModels;
using Coworking.Application.Contracts;
using Coworking.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Coworking.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IApiCaller _apiCaller; 

        public UserController(IUserService userService, IApiCaller apiCaller)
        {
            _userService = userService;
            _apiCaller = apiCaller;
        }

        /// <summary>
        /// GET all User
        /// </summary>
        /// <returns>User Collection</returns>
        [HttpGet]
        [Produces("application/json", Type = typeof(List<UserModel>))]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        /// <summary>
        /// GET a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(UserModel))]
        public async Task<IActionResult> Get(int id)
        {
            var response = await  _apiCaller.GetServiceResponse<Admin>("admin", id);
            var user = await _userService.GetUser(id);
            return Ok(user);
        }

        /// <summary>
        /// Add a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(401)]
        [Produces("application/json", Type = typeof(UserModel))]
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserModel user)
        {
            var newUser = await _userService.AddUser(UserMapper.Map(user));
            return Ok(newUser);
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        [HttpDelete("{id}")]
        [Produces("application/json", Type = typeof(bool))]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User</returns>
        [HttpPut]
        [Produces("application/json", Type = typeof(UserModel))]
        public async Task<IActionResult> UpdateUser([FromBody]UserModel user)
        {
            var updatedUser = await _userService.UpdateUser(UserMapper.Map(user));
            return Ok(updatedUser);
        }

    }
}