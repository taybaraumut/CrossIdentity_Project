using CrossIdentityProject.API.Models.IdentityModels;
using FluentValidation;
using Newtonsoft.Json;
using System.Text;

namespace CrossIdentityProject.API.Middlewares.LoginResponseMessageMiddlewares
{
    public class LoginResponseMessageAndValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public LoginResponseMessageAndValidationMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
        {
            _next = next;
            _serviceScopeFactory = serviceScopeFactory;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/api/Logins" && context.Request.Method == "POST")
            {
                var jsonRequestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();

                var content = Encoding.UTF8.GetBytes(jsonRequestBody);
                var requestBodyStream = new MemoryStream();
                requestBodyStream.Write(content, 0, content.Length);
                context.Request.Body = requestBodyStream;
                context.Request.Body.Seek(0, SeekOrigin.Begin);

                var loginModel = JsonConvert.DeserializeObject<LoginModel>(jsonRequestBody);

                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var validator = scope.ServiceProvider.GetRequiredService<IValidator<LoginModel>>();
                    var validationResult = await validator.ValidateAsync(loginModel!);

                    if (!validationResult.IsValid)
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsJsonAsync(validationResult.Errors.Select(x => x.ErrorMessage));
                        return;
                    }
                }

            }

            await _next(context);
        }

    }
}
