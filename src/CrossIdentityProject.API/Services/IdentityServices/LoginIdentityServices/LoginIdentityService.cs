using CrossIdentityProject.API.Entities;
using CrossIdentityProject.API.Models.IdentityModels;
using CrossIdentityProject.API.Services.ValidatorServices.LoginValidatorServices;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace CrossIdentityProject.API.Services.IdentityServices.LoginIdentityServices
{
    public class LoginIdentityService : ILoginIdentityService
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly ILoginValidatorService loginValidatorService;
        public LoginIdentityService(SignInManager<AppUser> signInManager,
               UserManager<AppUser> userManager,
               ILoginValidatorService loginValidatorService)

        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.loginValidatorService = loginValidatorService;
        }

        public async Task<string> LoginAsync(LoginModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                var user_info = await userManager.FindByNameAsync(model.Username);

                var name = user_info!.Name;
                var surname = user_info!.Surname;

                return JsonConvert.SerializeObject($"Welcome : {name + surname}");
            }
            else
            {
                return JsonConvert.SerializeObject("The Username or Password is Incorrect. Try again.");
            }
                    
        }
    }
}
