using CrossIdentityProject.API.Extensions.ContextConfigurationServiceExtensions;
using CrossIdentityProject.API.Extensions.IdentityConfigurationServiceExtensions;
using CrossIdentityProject.API.Extensions.ServiceExtensions;
using CrossIdentityProject.API.Extensions.ValidationServiceExtensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.AddIdentityConfigurationServiceExtension();
builder.AddValidationServiceExtension();
builder.AddServiceExtensions();
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

app.Run();
