using CrossIdentityProject.API.Services.IdentityServices.LoginIdentityServices;
using CrossIdentityProject.API.Services.IdentityServices.RegisterIdentityServices;
using CrossIdentityProject.API.Services.LogServices;
using CrossIdentityProject.API.Services.ValidatorServices.LoginValidatorServices;
using CrossIdentityProject.API.Services.ValidatorServices.RegisterValidatorServices;

namespace CrossIdentityProject.API.Extensions.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static WebApplicationBuilder AddServiceExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ILoginValidatorService, LoginValidatorService>();
            builder.Services.AddScoped<IRegisterValidatorService, RegisterValidatorService>();
            builder.Services.AddScoped<ILoginIdentityService, LoginIdentityService>();
            builder.Services.AddScoped<IRegisterIdentityService, RegisterIdentityService>();
            builder.Services.AddScoped<ILogService, LogService>();

            return builder;
        }
    }
}
