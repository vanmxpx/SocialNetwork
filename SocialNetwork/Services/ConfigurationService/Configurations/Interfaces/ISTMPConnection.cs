namespace SocialNetwork.Configurations{
    public interface ISTMPConnection
    {
        string Server{get;set;}
        string UserName{get;set;}
        string Password{get;set;}
        string Port{get;set;}
        bool UseSSL {get;set;}
    }
}