using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SocialNetwork.Configurations
{
    public class DafaultConfigLoader : IConfigLoader
    {
        public void ConfigProvider(IServiceCollection services, IConfigProvider provider)
        {
            SetConfig<IDatabaseScriptsOption>(services,provider.DatabaseScriptsOption);
            SetConfig<IConnectionStrings>(services,provider.ConnectionStrings);
            SetConfig<IDatabaseScriptsOption>(services,provider.DatabaseScriptsOption);
            SetConfig<ISTMPConnection> (services, provider.STMPConnection);
        }

        public IConfigProvider GetConfigProvider(IConfiguration config)
        {
            IConfigProvider configProvider = new DefaultConfigProvider()
            {
                DatabaseScriptsOption =  GetConf<DatabaseScriptsOption>(config,"DatabaseScriptsOption"),
                ConnectionStrings =  GetConf<ConnectionStrings>(config,"ConnectionStrings"),
                Logging =  GetConf<Logging>(config,"Logging"),
                STMPConnection = GetConf<STMPConnection>(config,"STMPConnection")
            };
            return configProvider;
        }
        
        private T GetConf<T>(IConfiguration config, string Path) where T : class
        {
            return config.GetSection(Path).Get<T>();
        }
        private void SetConfig<T>(IServiceCollection services, T config) where T : class
        {
            services.AddSingleton(config);
        }
       
    }
}