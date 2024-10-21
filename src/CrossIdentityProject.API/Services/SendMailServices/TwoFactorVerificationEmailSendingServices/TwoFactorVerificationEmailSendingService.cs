using System.Net.Mail;
using System.Net;
using System.Text;

namespace CrossIdentityProject.API.Services.SendMailServices.TwoFactorVerificationEmailSendingServices
{
    public class TwoFactorVerificationEmailSendingService : ITwoFactorVerificationEmailSendingService
    {
        public void TwoFactorVerificationEmailSend(string email, string verificationCode)
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
            mailBody.AppendFormat($"<h1>E-Mail Adresiniz : {email}</h1>");
            mailBody.AppendFormat("<br />");
            mailBody.AppendFormat($"<h1>İki Faktörlü Doğrulama Giriş Kodunuz : {verificationCode}</h1>");


            mailMessage.Body = mailBody.ToString();

            // E-postayı gönder
            client.Send(mailMessage);
        }
    }
}
