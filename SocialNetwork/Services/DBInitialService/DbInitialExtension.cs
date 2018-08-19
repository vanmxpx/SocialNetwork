using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using SocialNetwork.Configurations;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;


namespace SocialNetwork.Services.Extentions
{
    public static class DbInitialExtention
    {
        public static void AddDbService(this IServiceCollection services,IHostingEnvironment env, IConfigProvider provider)
        {
            if (env.IsDevelopment())
            {
                AddDatabaseConnection(services, provider.ConnectionStrings.LocalDatabase);
            }
            else
            {
                AddDatabaseConnection(services, provider.ConnectionStrings.RemoteDatabase);
            }
        }

        private static void AddDatabaseConnection(IServiceCollection services, string connection)
        {
            services.AddDbContextPool<ShortyContext>( // replace "YourDbContext" with the class name of your DbContext
                options => options.UseMySql(connection, // replace with your Connection String
                    mysqlOptions =>
                    {
                        mysqlOptions.ServerVersion(new Version(8, 0, 12), ServerType.MySql); // replace with your Server Version and Type
                    }
            ));
        }
    }
}