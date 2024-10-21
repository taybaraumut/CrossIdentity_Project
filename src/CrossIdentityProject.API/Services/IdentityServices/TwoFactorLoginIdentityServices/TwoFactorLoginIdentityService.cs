
using CrossIdentityProject.API.Entities;
using CrossIdentityProject.API.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace CrossIdentityProject.API.Services.IdentityServices.TwoFactorLoginIdentityServices
{
    public class TwoFactorLoginIdentityService : ITwoFactorLoginIdentityService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public TwoFactorLoginIdentityService(SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<string> TwoFactorLoginAsync(TwoFactorLoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);

            var isValid = await userManager.VerifyTwoFactorTokenAsync(user!, TokenOptions.DefaultEmailProvider, model.Token);

            if (isValid)
            {
                if (await userManager.VerifyTwoFactorTokenAsync(user!,TokenOptions.DefaultEmailProvider, model.Token))
                {
                    await signInManager.SignInAsync(user!, isPersistent: false);

                    var user_info = await userManager.FindByNameAsync(model.Username);

                    var name = user_info!.Name;
                    var surname = user_info!.Surname;
                    var email = user_info.Email;

                    return $"Welcome : {name + surname}";
                }
            }
            throw new Exception("Girmiş Olduğunuz Kod Hatalı");

        }
    }
}
