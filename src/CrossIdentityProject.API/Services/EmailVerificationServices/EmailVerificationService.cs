using CrossIdentityProject.API.Entities;
using CrossIdentityProject.API.Models.EmailVerificationModels;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace CrossIdentityProject.API.Services.EmailVerificationServices
{
    public class EmailVerificationService : IEmailMemberVerificationService
    {
        private readonly UserManager<AppUser> userManager;

        public EmailVerificationService(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<string> ConfirmEmailAsync(VerificationModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user!.Code == model.Code)
            {
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

                await userManager.ConfirmEmailAsync(user, token);

                return JsonConvert.SerializeObject("Verification Successful");
            }
            else
            {
                string message = "The Verification Code You Entered is Incorrect";
                int status_code = 400;
                throw new BadHttpRequestException(message, status_code);
            }
        }
    }
}
