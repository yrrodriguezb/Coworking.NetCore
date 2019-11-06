using System.Threading.Tasks;
using Api.DataAccess.Contracts.Repositories;
using Coworking.Api.Bussiness.Models;
using Coworking.Api.DataAccess;
using Coworking.Application.Contracts.Services;

namespace Coworking.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _AdminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _AdminRepository = adminRepository;
        }

        public async Task<string> GetAdminName(int id)
        {
            var entity = await _AdminRepository.Get(id);
            
            if (entity != null)
                return entity.Name;
            
            return string.Empty;
        }

        public async Task<Admin> AddAdmin(Admin admin)
        {
            var addedEntity = await _AdminRepository.Add(AdminMapper.Map(admin));
            return AdminMapper.Map(addedEntity);
        }

        
    }
}