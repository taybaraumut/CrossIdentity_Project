using CrossIdentityProject.UI.Models.EmailVerificationModels;

namespace CrossIdentityProject.UI.Services.EmailVerificationServices
{
    public interface IEmailVerificationService
    {
        public Task<bool> EmailVerification(VerificationModel model);
    }
}
