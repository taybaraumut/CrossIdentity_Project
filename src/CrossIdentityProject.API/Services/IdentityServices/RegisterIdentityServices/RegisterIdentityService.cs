using CrossIdentityProject.API.Entities;
using CrossIdentityProject.API.Middlewares.RegisterResponseMessageMiddlewares;
using CrossIdentityProject.API.Models.IdentityModels;
using CrossIdentityProject.API.Services.ValidatorServices.RegisterValidatorServices;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace CrossIdentityProject.API.Services.IdentityServices.RegisterIdentityServices
{
    public class RegisterIdentityService : IRegisterIdentityService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IRegisterValidatorService registerValidatorService;

        public RegisterIdentityService(UserManager<AppUser> userManager,
               IRegisterValidatorService registerValidatorService)
        {
            this.userManager = userManager;
            this.registerValidatorService = registerValidatorService;

        }
        public async Task<string> RegisterAsync(RegisterModel model)
        {
            AppUser user = new AppUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                UserName = model.Username,
                Email = model.Email,
                City = model.City,
                District = model.District,
                Code = 62,
            };

            var create_user = await userManager.CreateAsync(user, model.Password);

            if (create_user.Succeeded)
                return JsonConvert.SerializeObject("Registration Successful");
            else
                return JsonConvert.SerializeObject("Registration Failed");
        }
    }
}
