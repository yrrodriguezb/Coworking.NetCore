using Microsoft.Extensions.Configuration;

namespace Coworking.Application.Configuration
{
    public class AppConfig : IAppConfig
    {
        private readonly IConfiguration _configuration;

        public AppConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int MaxTrys => int.Parse(_configuration.GetSection("Polly:MaxTrys").Value);   
        public int SecondsToWait => int.Parse(_configuration.GetSection("Polly:TimeDelay").Value);   
        public string ServiceUrl => _configuration.GetSection("ServiceUrl:Url").Value;   
    }
}