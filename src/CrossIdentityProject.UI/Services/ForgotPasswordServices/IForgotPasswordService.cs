using CrossIdentityProject.UI.Models.IdentityViewModels;

namespace CrossIdentityProject.UI.Services.ForgotPasswordServices
{
    public interface IForgotPasswordService
    {
        public Task<bool> ResetPasswordEmail(ResetPasswordEmailViewModel model);
        public Task<bool> ResetPassword(ResetPasswordViewModel model);
    }
}
