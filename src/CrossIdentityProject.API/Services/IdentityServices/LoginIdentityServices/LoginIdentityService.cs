using CrossIdentityProject.API.DbContext;
using CrossIdentityProject.API.Entities;
using CrossIdentityProject.API.Models.IdentityModels;
using CrossIdentityProject.API.Services.LogServices;
using CrossIdentityProject.API.Services.ValidatorServices.LoginValidatorServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using System.Net;

namespace CrossIdentityProject.API.Services.IdentityServices.LoginIdentityServices
{
    public class LoginIdentityService : ILoginIdentityService
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly ILoginValidatorService loginValidatorService;
        private readonly ILogService logService;
        public LoginIdentityService(SignInManager<AppUser> signInManager,
               UserManager<AppUser> userManager,
               ILoginValidatorService loginValidatorService,
               ILogService logService)

        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.loginValidatorService = loginValidatorService;
            this.logService = logService;
        }

        public async Task<string> LoginAsync(LoginModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                var user_info = await userManager.FindByNameAsync(model.Username);

                var name = user_info!.Name;
                var surname = user_info!.Surname;
                var email = user_info.Email;

                logService.Login_Sucess_Logger(name,surname,email!);

                return JsonConvert.SerializeObject($"Welcome : {name + surname}");
            }
            else
            {
               throw new UnauthorizedAccessException("The Username or Password is Incorrect. Try again.");
            }
        }

    }
}
