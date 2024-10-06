using CrossIdentityProject.API.DbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace CrossIdentityProject.API.Extensions.ContextConfigurationServiceExtensions
{
    public static class ContextConfigurationServiceExtension
    {
        public static WebApplicationBuilder AddContextConfigurationServiceExtension(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<Context>(db =>
            {
                db.UseNpgsql(configuration);
            });

            return builder;
        }
    }
}
