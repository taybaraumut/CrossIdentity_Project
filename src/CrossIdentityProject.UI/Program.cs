using CrossIdentityProject.UI.Extensions.CookieConfigurationServiceExtensions;
using CrossIdentityProject.UI.Extensions.ServiceExtensions;
using CrossIdentityProject.UI.Extensions.ValidationConfigurationServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.AddValidationConfigurationServiceExtension();

builder.Services.AddHttpClient();

builder.AddCookieConfigurationServiceExtension();
builder.AddValidationConfigurationServiceExtension();
builder.AddServiceExtension();
builder.AddValidationServiceExtension();



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
