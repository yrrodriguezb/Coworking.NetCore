using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Coworking.Application.Configuration;
using Coworking.Application.Contracts;
using Newtonsoft.Json;

namespace Coworking.Application.ApiCaller
{
    public class ApiCaller : IApiCaller
    {
        private readonly HttpClient _httpClient;

        public ApiCaller(IAppConfig appConfig)
        {
            _httpClient = new HttpClient() 
            {
                BaseAddress = new Uri(appConfig.ServiceUrl)
            };

            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        public async Task<T> GetServiceResponse<T>(string controller, int id)
        {
            var response = await _httpClient.GetAsync($"{controller}/{id}");

            if (!response.IsSuccessStatusCode)
                return default(T);

            var result = response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result.Result);
        }
    }
}