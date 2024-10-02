using CrossIdentityProject.UI.Models.IdentityViewModels;
using CrossIdentityProject.UI.Services.ValidatorServices.LoginValidatorServices;
using CrossIdentityProject.UI.Services.ValidatorServices.RegisterValidatorServices;
using CrossIdentityProject.UI.ValidationRules.IdentityValidationRules;
using FluentValidation;

namespace CrossIdentityProject.UI.Extensions.ServiceExtensions
{
    public static class ServiceExtension
    {
        public static WebApplicationBuilder AddServiceExtension(this WebApplicationBuilder builder)
        { 
            builder.Services.AddScoped<IValidator<LoginViewModel>, LoginValidator>();
            builder.Services.AddScoped<IValidator<RegisterViewModel>, RegisterValidator>();

            return builder;
        }
    }
}
