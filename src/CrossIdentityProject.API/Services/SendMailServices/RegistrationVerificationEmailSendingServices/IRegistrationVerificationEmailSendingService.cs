namespace CrossIdentityProject.API.Services.SendMailServices.RegistrationVerificationEmailSendingServices
{
    public interface IRegistrationVerificationEmailSendingService
    {
        public void RegistrationVerificationEmailSend(string email, string name, string username, ushort verificationCode);
    }
}
