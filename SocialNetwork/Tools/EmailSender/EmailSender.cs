using System.Threading.Tasks;
using SocialNetwork.Configurations;

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
    }
}