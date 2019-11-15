using System.Threading.Tasks;
using Api.DataAccess.Contracts.Repositories;
using Coworking.Application.Configuration;
using Coworking.Application.Contracts.Services;
using Coworking.Application.Services;
using Coworking.Application.UnitTest.Config;
using Coworking.Application.UnitTest.MockRepository;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Application.Tests
{
    [TestClass]
    public class AdminServiceTest
    {
        private static IAdminService _adminService;

        // Se inicializa una sola vez, lo contrario de TestInitialize que inicaliza en cada metodo de prueba
        [ClassInitialize()]
        public static void Setup(TestContext context)
        {
            Mock<IAdminRepository> _adminRepository = new AdminRepositoryMock()._adminRepository;
            Mock<IAppConfig> _appConfig = new AppConfigMock()._appConfig;

            _adminService = new AdminService(_adminRepository.Object, _appConfig.Object);
        }

        [TestMethod]
        public async Task dado_un_id_devuelve_un_admin_ok()
        {
            // Preparación

            // Ejecución
            var result = await _adminService.GetAdmin(1);

            // Aseerción
            result.Name.Should().NotBeNullOrEmpty();
            result.Id.Should().NotBe(2);

        }

        [TestMethod]
        public async Task devuelve_una_lista_de_admin()
        {
            // Preparación

            // Ejecución
            var result = await _adminService.GetAllAdmins();

            // Aseerción
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCountGreaterOrEqualTo(1);

        }


        
    }
}
