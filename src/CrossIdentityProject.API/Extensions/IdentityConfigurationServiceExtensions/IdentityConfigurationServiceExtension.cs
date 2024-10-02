using CrossIdentityProject.API.DbContext;
using CrossIdentityProject.API.Entities;
using Microsoft.AspNetCore.Identity;

namespace CrossIdentityProject.API.Extensions.IdentityConfigurationServiceExtensions
{
    public static class IdentityConfigurationServiceExtension
    {
        public static WebApplicationBuilder AddIdentityConfigurationServiceExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<AppUser, AppRole>()
                   .AddEntityFrameworkStores<Context>()
                   .AddDefaultTokenProviders();

            return builder;
        }
    }
}
