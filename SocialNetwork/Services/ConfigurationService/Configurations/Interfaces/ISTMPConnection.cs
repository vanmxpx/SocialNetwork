namespace SocialNetwork.Configurations
{
    public interface ISTMPConnection
    {
        string Server { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        int Port { get; set; }
        bool UseSSL { get; set; }
        string CompanyName { get; set; }
        int TimeOut {get;set;}
    }
}