using System.Net.Mail;
using System.Net;
using System.Text;

namespace CrossIdentityProject.API.Services.SendMailServices.RegistrationVerificationEmailSendingServices
{
    public class RegistrationVerificationEmailSendingService : IRegistrationVerificationEmailSendingService
    {
        public void RegistrationVerificationEmailSend(string email, string name, string username, ushort verificationCode)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("umuttaybara452@gmail.com", "agbfyctfpnlmptxr");

            // E-posta mesajı oluşturun
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("umuttaybara452@gmail.com");
            mailMessage.To.Add(email);
            mailMessage.Subject = "Cross Identity Üyelik Doğrulama";
            mailMessage.IsBodyHtml = true;

            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat($"<h1>Kullanıcı Adınız : {username}</h1>");
            mailBody.AppendFormat("<br />");
            mailBody.AppendFormat($"<h1>Kullanıcı Adınız : {verificationCode}</h1>");
            mailBody.AppendFormat("<br/>");
            mailBody.AppendFormat($"<p>Kayıt Olduğunuz İçin Teşşekürler Sayın: {name}</p>");


            mailMessage.Body = mailBody.ToString();

            // E-postayı gönder
            client.Send(mailMessage);
        }
    }
}
