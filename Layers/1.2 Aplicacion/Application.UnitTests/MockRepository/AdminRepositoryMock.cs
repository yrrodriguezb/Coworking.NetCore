using System.Threading.Tasks;
using Api.DataAccess.Contracts.Entities;
using Api.DataAccess.Contracts.Repositories;
using Coworking.Application.UnitTest.Stubs;
using Moq;

namespace Coworking.Application.UnitTest.MockRepository
{
    public class AdminRepositoryMock 
    {
        public Mock<IAdminRepository> _adminRepository { get; set; }

        public AdminRepositoryMock()
        {
            _adminRepository = new Mock<IAdminRepository>();
            this.Setup();
        }

        private void Setup()
        {
            _adminRepository
                .Setup(x => x.Add(It.IsAny<AdminEntity>()))
                .ReturnsAsync(AdminStub.admin_1);

            _adminRepository
                .Setup(x => x.DeleteAsync(It.Is<int>(param => param.Equals(3))))
                .Returns(Task.Delay(5));

            _adminRepository
                .Setup(x => x.DeleteAsync(It.Is<int>(parametro => !parametro.Equals(3))))
                .Returns(Task.Delay(10));

            _adminRepository
                .Setup(x => x.Exists(It.IsAny<int>()))
                .ReturnsAsync(true);

            _adminRepository
                .Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(AdminStub.admin_1);

            _adminRepository
                .Setup(x => x.GetAll())
                .ReturnsAsync(AdminStub.listAdmin);

            _adminRepository
                .Setup(x => x.Update(It.IsAny<AdminEntity>()))
                .ReturnsAsync(AdminStub.admin_1);
        }

    }
}