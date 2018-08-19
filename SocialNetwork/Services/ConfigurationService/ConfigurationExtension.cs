using SocialNetwork.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SocialNetwork.Services.Extentions{
    public static class ConfigurationExtension{
        private static IConfigProvider provider{get;set;}
        public static void AddConfigurationProvider(this IServiceCollection services, IConfiguration config){
            IConfigLoader loader = new DafaultConfigLoader();
            provider = loader.GetConfigProvider(config);
        }

        public static IConfigProvider GetProvider(this IServiceCollection services){
            return provider;
        }
    }
}