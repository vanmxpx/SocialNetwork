using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;
using SocialNetwork.SignalRChatHub;
using SocialNetwork.Configurations;

namespace SocialNetwork
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        private void AddDatabaseConnection(IServiceCollection services, string connection)
        {
            services.AddDbContextPool<ShortyContext>( // replace "YourDbContext" with the class name of your DbContext
                options => options.UseMySql(Configuration.GetConnectionString("LocalDatabase"), // replace with your Connection String
                    mysqlOptions =>
                    {
                        mysqlOptions.ServerVersion(new Version(8, 0, 12), ServerType.MySql); // replace with your Server Version and Type
                    }
            ));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddConnectionStringSettings(Configuration);
            services.AddDatabaseScriptsOptionSettings(Configuration);
            services.AddSTMPConnectionSettings(Configuration);
            services.AddLoggingSettings(Configuration);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "client/dist";
            });

            if (Environment.IsDevelopment())
            {
                AddDatabaseConnection(services, "LocalDatabase");
            }
            else
            {
                AddDatabaseConnection(services, "RemoteDatabase");
            }

            services.AddSignalR();

            services.AddTransient<Intitializer>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Intitializer ini)
        {
            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chatHub");
            });
            app.UseMvc();

            if (Environment.IsDevelopment())
            {
                if (Configuration.GetValue<string>("DatabaseDataDeleteFillOption") == "DeleteFill")
                {
                    ini.DeleteAll().Wait();
                    ini.Seed().Wait();
                }

                app.UseDeveloperExceptionPage();

                // Позволяем получать запросы с отдельной ангуляр страницы (по умолчанию в браузере нельзя отправлять 
                // запросы на другой домен, порт и т.д.. Все это в целях безопасности)
                app.UseCors(builder =>
                    builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                );
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
                // На данный момент контракт HTTP считается устаревшим и не безопасным, 
                // используем HTTPS для всех запросов в продакшене
                app.UseHttpsRedirection();
            }

            // Укажем, что наше приложение будет использовать статические странички, сгенерированые ангуляр приложением.
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            // Для того, что бы наше приложение разворачивалось с Ангуляром, используем опцию,
            // которая позволяет запускать Single Page Application вместо привычных страниц в папке View
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "client";

                if (Environment.IsDevelopment())
                {
                    // Первый вариант запустит новое Angular приложение, второй же подключится по ссылке к уже существующему.
                    // Удобно использовать 2ой вариант, потому что два отдельно запущеных приложения клиента/сервера можно одновременно дебажить.
                    //spa.UseAngularCliServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}
