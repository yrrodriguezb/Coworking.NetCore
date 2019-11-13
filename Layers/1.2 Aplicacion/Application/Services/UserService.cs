using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DataAccess.Contracts.Repositories;
using Coworking.Api.Bussiness.Models;
using Coworking.Api.DataAccess;
using Coworking.Application.Contracts.Services;

namespace Coworking.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUser(int id)
        {
            var entity = await _userRepository.Get(id);
            return UserMapper.Map(entity);
        }

        public async Task<User> AddUser(User user)
        {
            var addedEntity = await _userRepository.Add(UserMapper.Map(user));
            return UserMapper.Map(addedEntity);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            return users.Select(UserMapper.Map);
        }

        public Task DeleteUser(int id)
        {
            return  _userRepository.DeleteAsync(id); 
        }

        public async Task<User> UpdateUser(User user)
        {
            var updated = await _userRepository.Update(UserMapper.Map(user));
            return UserMapper.Map(updated);
        }
    }
}