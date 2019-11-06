using System.Threading.Tasks;
using Api.DataAccess.Contracts.Repositories;
using Coworking.Application.Contracts.Services;

namespace Coworking.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IAdminService _AdminService;
        private readonly IUserRepository _UserRepository;

        public UserService(IAdminService adminService, IUserRepository userRepository)
        {
            _AdminService = adminService;
            _UserRepository = userRepository;
        }

        public async Task GetUserName(int idUser, int idAdmin)
        {
            var user = await _UserRepository.Get(idUser);

            await _AdminService.GetAdminName(idAdmin);
        }
    }
}