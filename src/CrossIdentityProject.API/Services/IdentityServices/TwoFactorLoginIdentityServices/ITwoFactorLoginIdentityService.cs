using CrossIdentityProject.API.Models.IdentityModels;

namespace CrossIdentityProject.API.Services.IdentityServices.TwoFactorLoginIdentityServices
{
    public interface ITwoFactorLoginIdentityService
    {
        public Task<string> TwoFactorLoginAsync(TwoFactorLoginModel model);
    }
}
