using CrossIdentityProject.API.Models.EmailVerificationModels;

namespace CrossIdentityProject.API.Services.EmailVerificationServices
{
    public interface IEmailVerificationService
    {
        public Task<string> ConfirmEmailAsync(VerificationModel model);
    }
}
