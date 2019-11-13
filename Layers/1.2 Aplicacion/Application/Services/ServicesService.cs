using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DataAccess.Contracts.Repositories;
using Coworking.Api.Bussiness.Models;
using Coworking.Api.DataAccess;
using Coworking.Application.Contracts.Services;

namespace Coworking.Application.Services
{
    public class ServicesService : IServicesService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServicesService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<Service> GetService(int id)
        {
            var entity = await _serviceRepository.Get(id);
            return ServiceMapper.Map(entity);
        }

        public async Task<Service> AddService(Service service)
        {
            var addedEntity = await _serviceRepository.Add(ServiceMapper.Map(service));
            return ServiceMapper.Map(addedEntity);
        }

        public async Task<IEnumerable<Service>> GetAllServices()
        {
            var services = await _serviceRepository.GetAll();
            return services.Select(ServiceMapper.Map);
        }

        public Task DeleteService(int id)
        {
            return  _serviceRepository.DeleteAsync(id); 
        }

        public async Task<Service> UpdateService(Service service)
        {
            var updated = await _serviceRepository.Update(ServiceMapper.Map(service));
            return ServiceMapper.Map(updated);
        }
    }
}