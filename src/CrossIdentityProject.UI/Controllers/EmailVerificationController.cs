using CrossIdentityProject.UI.Models.EmailVerificationModels;
using CrossIdentityProject.UI.Services.EmailVerificationServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrossIdentityProject.UI.Controllers
{
    [Authorize]
    public class EmailVerificationController : Controller
    {
        private readonly IEmailVerificationService emailVerificationService;

        public EmailVerificationController(IEmailVerificationService emailVerificationService)
        {
            this.emailVerificationService = emailVerificationService;
        }

        [HttpGet]
        public IActionResult EmailConfimation(string email)
        {
            TempData["email"] = email;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EmailConfimation(VerificationModel model)
        {
            var result = await emailVerificationService.EmailVerification(model);

            if (result == true)
                return RedirectToAction("SignIn", "Login");

            else
                return View();
        }
    }
}
