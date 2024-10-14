using CrossIdentityProject.API.Middlewares.LoginResponseMessageMiddlewares;
using CrossIdentityProject.API.Middlewares.RegisterResponseMessageMiddlewares;
using CrossIdentityProject.API.Middlewares.UserLoginAuthenticationMiddlewares;
using CrossIdentityProject.API.Middlewares.UserLoginEmailVerificationMiddlewares;

namespace CrossIdentityProject.API.Extensions.MiddlewareServiceExtensions
{
    public static class MiddlewareServiceExtension
    {
        public static IApplicationBuilder UseMiddlewareHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<RegisterResponseMessageAndValidationMiddleware>();
            app.UseMiddleware<LoginResponseMessageAndValidationMiddleware>();
            app.UseMiddleware<UserLoginEmailVerificationCheckMiddleware>();
            app.UseMiddleware<UserLoginAuthenticationMiddleware>();

            return app;
        }
    }
}
