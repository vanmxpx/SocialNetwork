using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SocialNetwork.Configurations
{
    public static class StartupConfigExtension
    {
        private static T SetConfig<T>(IServiceCollection services, IConfiguration configuration, string Path) where T : class
        {
            var settings = configuration.GetSection(Path);
            services.Configure<T>(settings);
            return settings.Get<T>();
        }
        public static ConnectionString AddConnectionStringSettings(this IServiceCollection services, IConfiguration configuration)
        {
            return SetConfig<ConnectionString>(services, configuration, "ConnectionStrings");
        }
        public static DatabaseScriptsOption AddDatabaseScriptsOptionSettings(this IServiceCollection services, IConfiguration configuration)
        {
            return SetConfig<DatabaseScriptsOption>(services, configuration, "DatabaseScriptsOption");
        }
        public static STMPConnection AddSTMPConnectionSettings(this IServiceCollection services, IConfiguration configuration)
        {
            return SetConfig<STMPConnection>(services, configuration, "STMPConnection");
        }
        public static Logging AddLoggingSettings(this IServiceCollection services, IConfiguration configuration)
        {
            SetConfig<LogLevel>(services, configuration, "LogLevel");
            return SetConfig<Logging>(services, configuration, "Logging");
        }
    }
}