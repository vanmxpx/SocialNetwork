using SocialNetwork.Configurations;
using SocialNetwork.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Extentions
{
    public static class AuthorizationExtension
    {

        public static void AddJWTAuthorization(this IServiceCollection services)
        {

            var key = Encoding.ASCII.GetBytes(services.GetProvider().AppSettings.Secret);
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

    }
}
