using CrossIdentityProject.UI.Models.IdentityViewModels;

namespace CrossIdentityProject.UI.Services.LoginServices
{
    public interface ILoginService
    {
        public Task<bool> LoginAsync(LoginViewModel model);
    }
}
