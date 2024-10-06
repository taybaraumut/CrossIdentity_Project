using CrossIdentityProject.API.Models.IdentityModels;

namespace CrossIdentityProject.API.Services.IdentityServices.LoginIdentityServices
{
    public interface ILoginIdentityService
    {
        public Task<string> LoginAsync(LoginModel model);
    }
}
