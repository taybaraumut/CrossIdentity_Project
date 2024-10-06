using CrossIdentityProject.API.Models.IdentityModels;

namespace CrossIdentityProject.API.Services.IdentityServices.RegisterIdentityServices
{
    public interface IRegisterIdentityService
    {
        public Task<string> RegisterAsync(RegisterModel model);
    }
}
