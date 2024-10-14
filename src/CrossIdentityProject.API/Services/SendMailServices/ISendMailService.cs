namespace CrossIdentityProject.API.Services.SendMailServices
{
    public interface ISendMailService
    {
        public void SendEmail(string email,string name,string username,ushort verificationCode);
    }
}
