using Microsoft.AspNetCore.Authentication.Cookies;

namespace CrossIdentityProject.UI.Extensions.CookieConfigurationServiceExtensions
{
    public static class CookieConfigurationServiceExtension
    {
        public static WebApplicationBuilder AddCookieConfigurationServiceExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication
                (CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            return builder;
        }
    }
}
