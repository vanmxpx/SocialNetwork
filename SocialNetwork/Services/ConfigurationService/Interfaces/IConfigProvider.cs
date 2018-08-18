using Microsoft.Extensions.Configuration;
namespace SocialNetwork.Configurations
{
    public interface IConfigProvider
    {
        #region  Data
        IDatabaseScriptsOption DatabaseScriptsOption { get; set; }
        IConnectionStrings ConnectionStrings { get; set; }
        ILogging Logging {get;set;}
        ISTMPConnection STMPConnection {get;set;}
        #endregion

    }
}