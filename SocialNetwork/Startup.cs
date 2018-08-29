using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;
using SocialNetwork.SignalRChatHub;
using SocialNetwork.Services;
using SocialNetwork.Configurations;
using SocialNetwork.Services.Extentions;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper();


            services.AddConfigurationProvider(Configuration);
            services.AddDbService(Environment, services.GetProvider());

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "client/dist";
            });




            services.AddSignalR();

            services.AddTransient<Initializer>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // конфигурация jwt аутентификации
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var credentialRepository = context.HttpContext.RequestServices
                            .GetRequiredService<IUnitOfWork>().CredentialRepository;
                        var Id = int.Parse(context.Principal.Identity.Name);
                        var profile = credentialRepository.GetById(Id);
                        if (profile == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfigProvider provider, Initializer ini)
        {
            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chatHub");
            });

 app.UseAuthentication();
            app.UseMvc();
           
            app.UseBDScripts(env,provider,ini);

            if (Environment.IsDevelopment())
            {
                

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

                if (env.IsDevelopment())
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
