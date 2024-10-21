namespace CrossIdentityProject.API.Services.SendMailServices.ResetPasswordEmailSendingServices
{
    public interface IResetPasswordEmailSendingService
    {
        public void ResetPasswordEmailSend(string name, string email, string username, string url);
    }
}
