using System.Threading.Tasks;
using SocialNetwork.Configurations;
using System;

namespace SocialNetwork.Services
{
    public abstract class EmailSender
    {
        protected  ISTMPConnection settings;
        public EmailSender(ISTMPConnection settings)
        {
            this.settings = settings;
        }
        public abstract Task SendEmailAsync(string email, string subject, string message);
        public abstract Task SendConfirmEmailAsync(string email, string password);
    }
}