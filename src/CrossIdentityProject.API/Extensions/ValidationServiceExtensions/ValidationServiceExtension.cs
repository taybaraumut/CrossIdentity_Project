using CrossIdentityProject.API.Models.IdentityModels;
using CrossIdentityProject.API.ValidationRules.IdentityValidationRules;
using FluentValidation;

namespace CrossIdentityProject.API.Extensions.ValidationServiceExtensions
{
    public static class ValidationServiceExtension
    {
        public static WebApplicationBuilder AddValidationServiceExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IValidator<LoginModel>, LoginValidator>();
            builder.Services.AddScoped<IValidator<RegisterModel>, RegisterValidator>();

            return builder;
        }
    }
}
