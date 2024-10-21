using CrossIdentityProject.API.Extensions.ContextConfigurationServiceExtensions;
using CrossIdentityProject.API.Extensions.IdentityConfigurationServiceExtensions;
using CrossIdentityProject.API.Extensions.MiddlewareServiceExtensions;
using CrossIdentityProject.API.Extensions.MinimalApiExtensions;
using CrossIdentityProject.API.Extensions.ServiceExtensions;
using CrossIdentityProject.API.Extensions.ValidationServiceExtensions;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Serilog;
using System.Text;



var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();


builder.AddIdentityConfigurationServiceExtension();
builder.AddValidationServiceExtension();
builder.AddServiceExtension();
builder.AddContextConfigurationServiceExtension();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("this_is_a_very_strong_and_secure_key_123456!")),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

builder.Services
    .AddAuthorization(opt =>
    {
        // Configure the default policy
        opt.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
            .RequireAuthenticatedUser()
            .Build();
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.UseMinimalApiHandler();
app.UseMiddlewareHandler();
app.Run();
