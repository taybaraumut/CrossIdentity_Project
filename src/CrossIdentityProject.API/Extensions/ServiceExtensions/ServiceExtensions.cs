using CrossIdentityProject.API.Services.ValidatorServices.LoginValidatorServices;
using CrossIdentityProject.API.Services.ValidatorServices.RegisterValidatorServices;

namespace CrossIdentityProject.API.Extensions.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static WebApplicationBuilder AddServiceExtensions(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ILoginValidatorService, LoginValidatorService>();
            builder.Services.AddScoped<IRegisterValidatorService, RegisterValidatorService>();

            return builder;
        }
    }
}
