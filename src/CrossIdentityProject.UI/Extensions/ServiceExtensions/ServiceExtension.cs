using CrossIdentityProject.UI.Models.IdentityViewModels;
using CrossIdentityProject.UI.Services.CityServices;
using CrossIdentityProject.UI.Services.EmailVerificationServices;
using CrossIdentityProject.UI.Services.ForgotPasswordServices;
using CrossIdentityProject.UI.Services.GenerateJwtTokenServices;
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
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<IEmailVerificationService, EmailVerificationService>();
            builder.Services.AddScoped<IForgotPasswordService, ForgotPasswordService>();
            builder.Services.AddScoped<IGenerateJwtTokenService, GenerateJwtTokenService>();

            return builder;
        }
    }
}
