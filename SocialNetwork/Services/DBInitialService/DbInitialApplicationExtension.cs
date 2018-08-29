using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using SocialNetwork.Configurations;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using Microsoft.AspNetCore.Builder;


namespace SocialNetwork.Services.Extentions
{
    public static class DbInitialApplicationExtention
    {
        public static void UseBDScripts(this IApplicationBuilder app, IHostingEnvironment env, IConfigProvider provider, Initializer ini)
        {
            if (env.IsDevelopment())
            {
                if (provider.DatabaseScriptsOption.InitialRemove)
                    ini.DeleteAll().Wait();
                if (provider.DatabaseScriptsOption.InitialFill)
                    ini.Seed().Wait();

            }

        }
    }
}