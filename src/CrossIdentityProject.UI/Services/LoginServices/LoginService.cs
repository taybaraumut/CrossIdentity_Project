
using CrossIdentityProject.UI.Models.IdentityViewModels;


namespace CrossIdentityProject.UI.Services.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient httpClient;

        public LoginService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> LoginAsync(LoginViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
