using CrossIdentityProject.API.DbContext;
using CrossIdentityProject.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CrossIdentityProject.API.Extensions.IdentityConfigurationServiceExtensions
{
    public static class IdentityConfigurationServiceExtension
    {
        public static WebApplicationBuilder AddIdentityConfigurationServiceExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<AppUser, AppRole>()
                   .AddEntityFrameworkStores<Context>()
                   .AddDefaultTokenProviders();

            builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(1);
            });


            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = false;

                options.SignIn.RequireConfirmedAccount = true;
                options.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultEmailProvider;
                options.SignIn.RequireConfirmedEmail = true;
            });

            return builder;
        }
    }
}
