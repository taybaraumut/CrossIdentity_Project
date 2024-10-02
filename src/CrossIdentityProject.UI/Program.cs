using CrossIdentityProject.UI.Models.IdentityViewModels;
using CrossIdentityProject.UI.Services.ValidatorServices.LoginValidatorServices;
using CrossIdentityProject.UI.Services.ValidatorServices.RegisterValidatorServices;
using CrossIdentityProject.UI.ValidationRules.IdentityValidationRules;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddFluentValidationAutoValidation(valid =>
{
    valid.DisableDataAnnotationsValidation = true;
});

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddHttpClient();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

builder.Services.AddScoped<ILoginValidatorService, LoginValidatorService>();
builder.Services.AddScoped<IValidator<LoginViewModel>,LoginValidator>();
builder.Services.AddScoped<IValidator<RegisterViewModel>,RegisterValidator>();
builder.Services.AddScoped<IRegisterValidatorService,RegisterValidatorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=SignIn}/{id?}");

app.Run();
