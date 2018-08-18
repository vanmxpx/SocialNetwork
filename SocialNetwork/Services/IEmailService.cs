namespace SocialNetwork.Services{
    public interface IEmailService{
        void sendConfirmEmail(string to, string content);
    }
}