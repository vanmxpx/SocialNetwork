namespace SocialNetwork.Configurations{
    public class STMPConnection : ISTMPConnection{
        public string Server {get;set;}
        public string UserName {get;set;}
        public string Password {get;set;}
        public string Port{get;set;}
        public bool UseSSL {get;set;}
    }
}