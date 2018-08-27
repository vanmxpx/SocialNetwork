namespace SocialNetwork.Configurations{
    public class DatabaseScriptsOption : IDatabaseScriptsOption{
        public bool InitialRemove{get;set;}
        public bool InitialFill{get;set;}
    }
}