using CrossIdentityProject.API.Entities;
using CrossIdentityProject.API.Models.IdentityModels;
using CrossIdentityProject.API.Services.SendMailServices.ResetPasswordEmailSendingServices;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;

namespace CrossIdentityProject.API.Services.IdentityServices.ForgotPasswordServices
{
    public class ForgotPasswordService : IForgotPasswordService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IResetPasswordEmailSendingService resetPasswordEmailSendingService;

        public ForgotPasswordService(UserManager<AppUser> userManager, IResetPasswordEmailSendingService resetPasswordEmailSendingService)
        {
            this.userManager = userManager;
            this.resetPasswordEmailSendingService = resetPasswordEmailSendingService;
        }

        public async Task<string> PasswordResetTokenAsync(ResetPasswordEmailModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                throw new Exception("No Such User Found");
            }

            var token = await userManager.GeneratePasswordResetTokenAsync(user!);

            var resetUrl = $"https://localhost:44340/ForgotPassword/ResetPassword/?token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(user!.Email!)}";

            resetPasswordEmailSendingService.ResetPasswordEmailSend(user.Name, user.Email!, user.UserName!, resetUrl);


            return JsonConvert.SerializeObject((new { token = token, url = resetUrl }));
        }

        public async Task<bool> VerifyPasswordResetTokenAsync(ResetPasswordModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            var result = await userManager.ResetPasswordAsync(user!, model.Token, model.NewPassword);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}
