using System.Net;

namespace CrossIdentityProject.API.Middlewares.UserLoginAuthenticationMiddlewares
{
    public class UserLoginAuthenticationMiddleware
    {
        private RequestDelegate next;

        public UserLoginAuthenticationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/api/Logins" && context.Request.Method == "POST")
            {
                try
                {
                    await next(context);
                }
                catch (UnauthorizedAccessException ex)
                {
                   context.Response.StatusCode = StatusCodes.Status400BadRequest;
                   await context.Response.WriteAsJsonAsync(ex.Message);
                   return;
                }                
            }
            else
            {
                await next(context);
            }
           
        } 
    }
}
