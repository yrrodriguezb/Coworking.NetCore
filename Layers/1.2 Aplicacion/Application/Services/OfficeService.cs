using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DataAccess.Contracts.Repositories;
using Coworking.Api.Bussiness.Models;
using Coworking.Api.DataAccess;
using Coworking.Application.Contracts.Services;

namespace Coworking.Application.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository _officeRepository;

        public OfficeService(IOfficeRepository officeRepository)
        {
            _officeRepository = officeRepository;
        }

        public async Task<Office> GetOffice(int id)
        {
            var office = await _officeRepository.Get(id);
            return OfficeMapper.Map(office);
        }

        public async Task<Office> AddOffice(Office office)
        {
            var addedEntity = await _officeRepository.Add(OfficeMapper.Map(office));
            return OfficeMapper.Map(addedEntity);
        }

        public async Task<IEnumerable<Office>> GetAllOffices()
        {
            var offices = await _officeRepository.GetAll();
            return offices.Select(OfficeMapper.Map);
        }

        public Task DeleteOffice(int id)
        {
            return  _officeRepository.DeleteAsync(id); 
        }

        public async Task<Office> UpdateOffice(Office office)
        {
            var updated = await _officeRepository.Update(OfficeMapper.Map(office));
            return OfficeMapper.Map(updated);
        }
    }
}