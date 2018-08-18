using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace SocialNetwork.Configurations
{
    public interface IConfigLoader
    {
        IConfigProvider GetConfigProvider(IConfiguration config);
        void ConfigProvider(IServiceCollection services, IConfigProvider provider);
    }
}