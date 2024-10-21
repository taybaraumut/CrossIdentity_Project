using CrossIdentityProject.API.Models.EmailVerificationModels;

namespace CrossIdentityProject.API.Services.EmailVerificationServices
{
    public interface IEmailMemberVerificationService
    {
        public Task<string> ConfirmEmailAsync(VerificationModel model);
    }
}
