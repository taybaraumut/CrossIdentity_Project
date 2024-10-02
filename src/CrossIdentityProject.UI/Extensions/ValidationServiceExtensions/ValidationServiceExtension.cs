using CrossIdentityProject.UI.Models.IdentityViewModels;
using CrossIdentityProject.UI.ValidationRules.IdentityValidationRules;
using FluentValidation;

namespace CrossIdentityProject.UI.Extensions.ValidationConfigurationServiceExtensions
{
    public static class ValidationServiceExtension
    {
        public static WebApplicationBuilder AddValidationServiceExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IValidator<LoginViewModel>, LoginValidator>();
            builder.Services.AddScoped<IValidator<RegisterViewModel>, RegisterValidator>();

            return builder;
        }
    }
}
