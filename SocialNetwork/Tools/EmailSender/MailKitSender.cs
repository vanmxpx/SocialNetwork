using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using SocialNetwork.Configurations;
using System;

namespace SocialNetwork.Services
{
    public class MailKitSender : EmailSender
    {
        
        public MailKitSender(ISTMPConnection settings) : base(settings)
        {

        }

        public override async Task SendConfirmEmailAsync(string email, string password)
        {
            await SendEmailAsync(email, "Confirm email", "http://localhost:5000/api/registration/" + email + "/" + Sha256Service.Convert(email + password));
        }

        public override async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress(settings.CompanyName, settings.UserName));
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = message
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(settings.Server, settings.Port, settings.UseSSL);
                    await client.AuthenticateAsync(settings.UserName, settings.Password);
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }
            }
            catch
            {
                throw new Exception();
            }

        }
    }
}