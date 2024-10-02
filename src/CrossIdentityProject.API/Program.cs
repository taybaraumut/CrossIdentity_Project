using CrossIdentityProject.API.DbContext;
using CrossIdentityProject.API.Entities;
using CrossIdentityProject.API.Models.IdentityModels;
using CrossIdentityProject.API.Services.ValidatorServices.LoginValidatorServices;
using CrossIdentityProject.API.Services.ValidatorServices.RegisterValidatorServices;
using CrossIdentityProject.API.ValidationRules.IdentityValidationRules;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IValidator<LoginModel>,LoginValidator>();
builder.Services.AddScoped<IValidator<RegisterModel>,RegisterValidator>();
builder.Services.AddScoped<ILoginValidatorService, LoginValidatorService>();
builder.Services.AddScoped<IRegisterValidatorService, RegisterValidatorService>();


builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/Auth/Login";
	options.LogoutPath = "/Auth/Logout";
	options.AccessDeniedPath = "/Auth/AccessDenied";
	options.SlidingExpiration = true;
});

var configuration = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<Context>(db =>
{
    db.UseNpgsql(configuration);
});

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
