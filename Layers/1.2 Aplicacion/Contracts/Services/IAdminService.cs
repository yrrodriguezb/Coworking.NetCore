using System.Collections.Generic;
using System.Threading.Tasks;
using Coworking.Api.Bussiness.Models;

namespace Coworking.Application.Contracts.Services
{
    public interface IAdminService
    {
        Task<IEnumerable<Admin>> GetAllAdmins();
        Task<Admin> GetAdmin(int id);
        Task<Admin> AddAdmin(Admin admin);
        Task DeleteAdmin(int id);
        Task<Admin> UpdateAdmin(Admin admin);
    }
}