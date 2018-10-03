using Microsoft.Extensions.Configuration;
namespace SocialNetwork.Configurations
{
    public class DefaultConfigProvider : IConfigProvider
    {
        private IConnectionStrings connectionString;
        private IDatabaseScriptsOption databaseScriptsOption;
        private ILogging logging;
        private ISTMPConnection stmpConnection;
        private IAppSettings appSettings;

        public IDatabaseScriptsOption DatabaseScriptsOption
        {
            get
            {
                return databaseScriptsOption;
            }
            set
            {
                databaseScriptsOption = value;
            }
        }
        public IConnectionStrings ConnectionStrings
        {
            get
            {
                return connectionString;
            }
            set
            {
                connectionString = value;
            }
        }
        public ILogging Logging
        {
            get
            {
                return logging;
            }
            set
            {
                logging = value;
            }
        }
        public ISTMPConnection STMPConnection
        {
            get
            {
                return stmpConnection;
            }
            set
            {
                stmpConnection = value;
            }
        }
        public IAppSettings AppSettings
        {
            get
            {
                return appSettings;
            }
            set
            {
                appSettings = value;
            }
        }
    }
}