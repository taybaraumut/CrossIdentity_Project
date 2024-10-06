using CrossIdentityProject.API.Middlewares.LoginResponseMessageMiddlewares;
using CrossIdentityProject.API.Middlewares.RegisterResponseMessageMiddlewares;

namespace CrossIdentityProject.API.Extensions.MiddlewareServiceExtensions
{
    public static class MiddlewareServiceExtension
    {
        public static IApplicationBuilder UseMiddlewareHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<RegisterResponseMessageAndValidationMiddleware>();
            app.UseMiddleware<LoginResponseMessageAndValidationMiddleware>();

            return app;
        }
    }
}
