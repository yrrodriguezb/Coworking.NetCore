using Coworking.Application.Configuration;
using Moq;

namespace Coworking.Application.UnitTest.Config
{
    public class AppConfigMock
    {
        public Mock<IAppConfig> _appConfig { get; set; }

        public AppConfigMock()
        {
            _appConfig = new Mock<IAppConfig>();
        }

        private void Setup()
        {
           
        }
    }
}