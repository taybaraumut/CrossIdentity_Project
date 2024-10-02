using CrossIdentityProject.UI.Models.IdentityViewModels;
using CrossIdentityProject.UI.ValidationRules.IdentityValidationRules;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace CrossIdentityProject.UI.Extensions.ValidationConfigurationServiceExtensions
{
    public static class ValidationConfigurationServiceExtension
    {
        public static WebApplicationBuilder AddValidationConfigurationServiceExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddFluentValidationClientsideAdapters();

            builder.Services.AddFluentValidationAutoValidation(valid =>
            {
                valid.DisableDataAnnotationsValidation = true;
            });

            builder.Services.AddValidatorsFromAssemblyContaining<LoginValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<RegisterValidator>();

            return builder;
        }
    }
}
