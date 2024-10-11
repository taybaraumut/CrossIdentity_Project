using CrossIdentityProject.API.Entities;
using CrossIdentityProject.API.Models.IdentityModels;
using CrossIdentityProject.API.Services.LogServices;
using CrossIdentityProject.API.Services.ValidatorServices.RegisterValidatorServices;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace CrossIdentityProject.API.Services.IdentityServices.RegisterIdentityServices
{
    public class RegisterIdentityService : IRegisterIdentityService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IRegisterValidatorService registerValidatorService;
        private readonly ILogService logService;

        public RegisterIdentityService(UserManager<AppUser> userManager,
               IRegisterValidatorService registerValidatorService,
               ILogService logService)
        {
            this.userManager = userManager;
            this.registerValidatorService = registerValidatorService;
            this.logService = logService;
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
            {
                logService.Register_Sucess_Logger(user.Name, user.Surname, user.Email, user.UserName, user.District, user.City);
                return JsonConvert.SerializeObject("Registration Successful");
            }
            else
            {
                return JsonConvert.SerializeObject("Registration Failed");
            }
               
        }
    }
}
