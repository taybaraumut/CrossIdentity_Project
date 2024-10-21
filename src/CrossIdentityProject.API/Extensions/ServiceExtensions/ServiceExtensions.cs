using CrossIdentityProject.API.Services.EmailVerificationServices;
using CrossIdentityProject.API.Services.IdentityServices.ChangePasswordServices;
using CrossIdentityProject.API.Services.IdentityServices.ForgotPasswordServices;
using CrossIdentityProject.API.Services.IdentityServices.LoginIdentityServices;
using CrossIdentityProject.API.Services.IdentityServices.RegisterIdentityServices;
using CrossIdentityProject.API.Services.IdentityServices.TwoFactorLoginIdentityServices;
using CrossIdentityProject.API.Services.IdentityServices.UserProfileInfoServices;
using CrossIdentityProject.API.Services.LogServices;
using CrossIdentityProject.API.Services.RandomCodeServices;
using CrossIdentityProject.API.Services.SendMailServices.RegistrationVerificationEmailSendingServices;
using CrossIdentityProject.API.Services.SendMailServices.ResetPasswordEmailSendingServices;
using CrossIdentityProject.API.Services.SendMailServices.TwoFactorVerificationEmailSendingServices;
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
            builder.Services.AddScoped<IRandomCodeService, RandomCodeService>();
            builder.Services.AddScoped<IRegistrationVerificationEmailSendingService, RegistrationVerificationEmailSendingService>();
            builder.Services.AddScoped<IEmailMemberVerificationService,EmailVerificationService>();
            builder.Services.AddScoped<ITwoFactorVerificationEmailSendingService, TwoFactorVerificationEmailSendingService>();
            builder.Services.AddScoped<ITwoFactorLoginIdentityService, TwoFactorLoginIdentityService>();
            builder.Services.AddScoped<IForgotPasswordService, ForgotPasswordService>();
            builder.Services.AddScoped<IResetPasswordEmailSendingService, ResetPasswordEmailSendingService>();
            builder.Services.AddScoped<IChangePasswordService, ChangePasswordService>();
            builder.Services.AddScoped<IUserProfileInfoService, UserProfileInfoService>();

            return builder;
        }
    }
}
