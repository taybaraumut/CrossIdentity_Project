using CrossIdentityProject.UI.Models.IdentityViewModels;
using CrossIdentityProject.UI.Services.GenerateJwtTokenServices;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CrossIdentityProject.UI.Services.ForgotPasswordServices
{
    public class ForgotPasswordService : IForgotPasswordService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IGenerateJwtTokenService generateJwtTokenService;

        public ForgotPasswordService(IHttpClientFactory httpClientFactory, IGenerateJwtTokenService generateJwtTokenService)
        {
            this.httpClientFactory = httpClientFactory;
            this.generateJwtTokenService = generateJwtTokenService;
        }

        public async Task<bool> ResetPasswordEmail(ResetPasswordEmailViewModel model)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:44357/api/ForgotPasswords/GetPassword", model);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ResetPassword(ResetPasswordViewModel model)
        {
            var token = await generateJwtTokenService.JwtToken();

            var client = httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            var response = await client.PostAsJsonAsync("https://localhost:44357/api/ForgotPasswords/ResetPassword", model);
            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }       
    }
}
