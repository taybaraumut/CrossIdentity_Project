using CrossIdentityProject.UI.Models;
using Newtonsoft.Json;

namespace CrossIdentityProject.UI.Services.GenerateJwtTokenServices
{
    public class GenerateJwtTokenService : IGenerateJwtTokenService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public GenerateJwtTokenService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<string> JwtToken()
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.PostAsync("https://localhost:44357/api/GenerateJwtTokens", null);
            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                var jsondata = JsonConvert.DeserializeObject<GenerateToken>(body);
                return jsondata!.Token;
            }
            throw new Exception("System Error");
        }
    }
}
