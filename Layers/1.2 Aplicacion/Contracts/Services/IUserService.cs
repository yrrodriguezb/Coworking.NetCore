using System.Collections.Generic;
using System.Threading.Tasks;
using Coworking.Api.Bussiness.Models;

namespace Coworking.Application.Contracts.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(int id);
        Task<User> AddUser(User user);
        Task DeleteUser(int id);
        Task<User> UpdateUser(User user);
    }
}