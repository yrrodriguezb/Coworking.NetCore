using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DataAccess.Contracts.Repositories;
using Coworking.Api.Bussiness.Models;
using Coworking.Api.DataAccess;
using Coworking.Application.Configuration;
using Coworking.Application.Contracts.Services;
using Microsoft.Extensions.Caching.Memory;
using Polly;

namespace Coworking.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _AdminRepository;
        private readonly IAppConfig _appConfig;
        // private readonly IMemoryCache _memoryCache;

        public AdminService(IAdminRepository adminRepository, IAppConfig appConfig) //, IMemoryCache memoryCache)
        {
            _AdminRepository = adminRepository;
            _appConfig = appConfig;
            //_memoryCache = memoryCache;

            // MemoryCacheEntryOptions chacheConfig = new MemoryCacheEntryOptions();
            // chacheConfig.Priority = CacheItemPriority.Normal;
            // chacheConfig.AbsoluteExpiration = DateTime.Now.AddMinutes(5); // appconfig.CacheExpiredInMinutes
        }

        public async Task<Admin> GetAdmin(int id)
        {
            var entity = await _AdminRepository.Get(id);
            return AdminMapper.Map(entity);
        }

        public async Task<Admin> AddAdmin(Admin admin)
        {
            var maxTrys = _appConfig.MaxTrys;
            var timeToWait =  TimeSpan.FromSeconds(_appConfig.SecondsToWait);

            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(maxTrys, i => timeToWait);

            // Politica para reintentar consultar llegado el caso exista un error en el servidor
            return await retryPolity.ExecuteAsync(async () => {
                var addedEntity = await _AdminRepository.Add(AdminMapper.Map(admin));
                return AdminMapper.Map(addedEntity);
            });
        }

        public async Task<IEnumerable<Admin>> GetAllAdmins()
        {
            var admins = await _AdminRepository.GetAll();
            return admins.Select(AdminMapper.Map);
        }

        public Task DeleteAdmin(int id)
        {
            return  _AdminRepository.DeleteAsync(id); 
        }

        public async Task<Admin> UpdateAdmin(Admin admin)
        {
            var updated = await _AdminRepository.Update(AdminMapper.Map(admin));
            return AdminMapper.Map(updated);
        }
    }
}