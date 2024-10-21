using CrossIdentityProject.API.Models.IdentityModels;

namespace CrossIdentityProject.API.Services.IdentityServices.ForgotPasswordServices
{
    public interface IForgotPasswordService
    {
        public Task<string> PasswordResetTokenAsync(ResetPasswordEmailModel model);
        public Task<bool> VerifyPasswordResetTokenAsync(ResetPasswordModel model);
    }
}
