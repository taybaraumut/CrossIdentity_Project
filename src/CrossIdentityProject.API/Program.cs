using CrossIdentityProject.API.Extensions.ContextConfigurationServiceExtensions;
using CrossIdentityProject.API.Extensions.IdentityConfigurationServiceExtensions;
using CrossIdentityProject.API.Extensions.MiddlewareServiceExtensions;
using CrossIdentityProject.API.Extensions.ServiceExtensions;
using CrossIdentityProject.API.Extensions.ValidationServiceExtensions;
using Microsoft.AspNetCore.Identity;
using Serilog;



var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    //options.User.AllowedUserNameCharacters =
    //"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

builder.AddIdentityConfigurationServiceExtension();
builder.AddValidationServiceExtension();
builder.AddServiceExtension();
builder.AddContextConfigurationServiceExtension();


//builder.Services.ConfigureApplicationCookie(options =>
//{
//	options.LoginPath = "/Auth/Login";
//	options.LogoutPath = "/Auth/Logout";
//	options.AccessDeniedPath = "/Auth/AccessDenied";
//	options.SlidingExpiration = true;
//});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseMiddlewareHandler();
app.Run();
