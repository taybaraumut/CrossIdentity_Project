using CrossIdentityProject.UI.Models.IdentityViewModels;
using CrossIdentityProject.UI.Services.EmailVerificationServices;
using CrossIdentityProject.UI.Services.ForgotPasswordServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrossIdentityProject.UI.Controllers
{
    [Authorize]
    public class ForgotPasswordController : Controller
    {
        private readonly IForgotPasswordService forgotPasswordService;

        public ForgotPasswordController(IForgotPasswordService forgotPasswordService)
        {
            this.forgotPasswordService = forgotPasswordService;
        }

        [HttpGet]
        public IActionResult ResetPasswordEmail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPasswordEmail(ResetPasswordEmailViewModel model)
        {
            var result = await forgotPasswordService.ResetPasswordEmail(model);
            if (result == true)
            {
                TempData["Message"] = "Şifre Sıfırlama Linki Mailinize Gönderilmiştir";
                return View();
            }
            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(string token,string email)
        {
            TempData["token"] = token;
            TempData["email"] = email;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var result = await forgotPasswordService.ResetPassword(model);
            if (result == true)
                return RedirectToAction("SignIn", "Login");
            else
                return View();
        }
    }
}
