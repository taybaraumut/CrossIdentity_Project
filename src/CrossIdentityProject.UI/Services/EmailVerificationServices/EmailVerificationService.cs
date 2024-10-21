
using CrossIdentityProject.UI.Models.EmailVerificationModels;
using CrossIdentityProject.UI.Services.GenerateJwtTokenServices;
using System.Net.Http.Headers;
using System.Reflection;

namespace CrossIdentityProject.UI.Services.EmailVerificationServices
{
    public class EmailVerificationService : IEmailVerificationService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IGenerateJwtTokenService generateJwtTokenService;

        public EmailVerificationService(IHttpClientFactory httpClientFactory, IGenerateJwtTokenService generateJwtTokenService)
        {
            this.httpClientFactory = httpClientFactory;
            this.generateJwtTokenService = generateJwtTokenService;
        }

        public async Task<bool> EmailVerification(VerificationModel model)
        {
            var token = await generateJwtTokenService.JwtToken();

            var client = httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            var response = await client.PostAsJsonAsync("https://localhost:44357/api/EmailVerifications", model);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
