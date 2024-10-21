using Bogus.DataSets;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace CrossIdentityProject.API.Services.SendMailServices.ResetPasswordEmailSendingServices
{
    public class ResetPasswordEmailSendingService : IResetPasswordEmailSendingService
    {
        public void ResetPasswordEmailSend(string name,string email,string username,string url)
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
            mailBody.AppendFormat($"<a href='{url}'>Şifre Sıfırlama Url : {url}</h1>");
            mailBody.AppendFormat("<br/>");
            mailBody.AppendFormat($"<p>Kayıt Olduğunuz İçin Teşşekürler Sayın: {name}</p>");


            mailMessage.Body = mailBody.ToString();

            // E-postayı gönder
            client.Send(mailMessage);
        }
    }
}
