namespace E_Shop.Data.Identity
{
    using System.Net.Mail;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;

    /// <summary>
    ///     A way to send messages via Email
    /// </summary>
    public interface IEmailSender : IIdentityMessageService
    {
    }

    /// <summary>
    ///    Email sender for Nixelt.Store
    /// </summary>
    public class EmailSender : IEmailSender
    {
        private const string Host = "nixelt.store";
        private const int Port = 25;
        private const string From = "noreply@nixelt.store";
        private const string Pass = "vb73nB70tY";

        public Task SendAsync(IdentityMessage message)
        {
            var client = new SmtpClient(Host, Port)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(From, Pass),
                EnableSsl = false
            };

            var mail = new MailMessage(From, message.Destination)
            {
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = true
            };

            return client.SendMailAsync(mail);
        }
    }
}
