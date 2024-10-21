namespace CrossIdentityProject.API.Services.SendMailServices.TwoFactorVerificationEmailSendingServices
{
    public interface ITwoFactorVerificationEmailSendingService
    {
        public void TwoFactorVerificationEmailSend(string email,string verificationCode);
    }
}
