using CrossIdentityProject.API.Entities;
using CrossIdentityProject.API.Models.IdentityModels;
using CrossIdentityProject.API.Services.LogServices;
using CrossIdentityProject.API.Services.RandomCodeServices;
using CrossIdentityProject.API.Services.SendMailServices.TwoFactorVerificationEmailSendingServices;
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
        private readonly ILogService logService;
        private readonly ITwoFactorVerificationEmailSendingService twoFactorVerificationEmailSendingService;
        private readonly IRandomCodeService randomCodeService;

        public LoginIdentityService(SignInManager<AppUser> signInManager,
               UserManager<AppUser> userManager,
               ILoginValidatorService loginValidatorService,
               ILogService logService,
               ITwoFactorVerificationEmailSendingService twoFactorVerificationEmailSendingService,
               IRandomCodeService randomCodeService)

        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.loginValidatorService = loginValidatorService;
            this.logService = logService;
            this.twoFactorVerificationEmailSendingService = twoFactorVerificationEmailSendingService;
            this.randomCodeService = randomCodeService;
        }

        public async Task<string> LoginAsync(LoginModel model)
        {

            var user = await userManager.FindByNameAsync(model.Username);
            var passwordCheck = await userManager.CheckPasswordAsync(user!, model.Password);

            if((user != null) && (passwordCheck))
            {
                if (user.EmailConfirmed != false)
                {
                    if (await userManager.GetTwoFactorEnabledAsync(user))
                    {
                        var token = await userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultEmailProvider);

                        twoFactorVerificationEmailSendingService.TwoFactorVerificationEmailSend(user.Email!, token);

                        return "true";

                    }
                    else
                    {
                        var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: false, lockoutOnFailure: true);

                        if (result.Succeeded)
                        {
                            var user_info = await userManager.FindByNameAsync(model.Username);

                            var name = user_info!.Name;
                            var surname = user_info!.Surname;
                            var email = user_info.Email;

                            logService.Login_Sucess_Logger(name, surname, email!);

                            return JsonConvert.SerializeObject($"Welcome : {name + surname}");
                        }
                        else
                        {
                            throw new UnauthorizedAccessException("Email Veya Parola Hatalı");
                        }
                    }

                }
                else
                {
                    throw new Exception("Hesabınızı Lütfen Doğrulayınız");
                }
            }

            throw new UnauthorizedAccessException("Email Veya Parola Hatalı");
        }
    }
}
