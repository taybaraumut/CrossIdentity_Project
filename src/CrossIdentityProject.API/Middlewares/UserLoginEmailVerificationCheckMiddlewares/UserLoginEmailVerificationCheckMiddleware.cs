namespace CrossIdentityProject.API.Middlewares.UserLoginEmailVerificationMiddlewares
{
    public class UserLoginEmailVerificationCheckMiddleware
    {
        private RequestDelegate next;

        public UserLoginEmailVerificationCheckMiddleware(RequestDelegate next)
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
                catch (Exception ex)
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
