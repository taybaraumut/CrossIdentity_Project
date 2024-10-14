using CrossIdentityProject.UI.Models.EmailVerificationModels;
using Microsoft.AspNetCore.Mvc;

namespace CrossIdentityProject.UI.Controllers
{
    public class EmailVerificationController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public EmailVerificationController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
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
            var client = httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:44357/api/EmailVerifications", model);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }
    }
}
