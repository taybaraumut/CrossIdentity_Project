
using CrossIdentityProject.UI.Models.CityModels;
using CrossIdentityProject.UI.Services.GenerateJwtTokenServices;
using System.Net.Http.Headers;

namespace CrossIdentityProject.UI.Services.CityServices
{
    public class CityService : ICityService
    {
        private IHttpClientFactory httpClientFactory;
        private readonly IGenerateJwtTokenService generateJwtTokenService;

        public CityService(IHttpClientFactory httpClientFactory, IGenerateJwtTokenService generateJwtTokenService)
        {
            this.httpClientFactory = httpClientFactory;
            this.generateJwtTokenService = generateJwtTokenService;
        }

        public async Task<List<CityModel>> GetCities()
        {
            var token = await generateJwtTokenService.JwtToken();

            var client = httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",token);

            var response = await client.GetFromJsonAsync<List<CityModel>>("https://localhost:44357/api/minimal_api/GetCities");
            return response!.ToList();
        }
    }
}
