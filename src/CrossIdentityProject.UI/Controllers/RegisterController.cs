using CrossIdentityProject.UI.Models.IdentityViewModels;
using CrossIdentityProject.UI.Services.GenerateJwtTokenServices;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace CrossIdentityProject.UI.Controllers
{
    public class RegisterController : Controller
    {
		private readonly IHttpClientFactory httpClientFactory;
		private readonly IGenerateJwtTokenService generateJwtTokenService;

        public RegisterController(IHttpClientFactory httpClientFactory, IGenerateJwtTokenService generateJwtTokenService)
        {
            this.httpClientFactory = httpClientFactory;
            this.generateJwtTokenService = generateJwtTokenService;
        }
        [HttpGet]
		public IActionResult SignUp()
        {
			return View();
        }

		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<IActionResult> SignUp(RegisterViewModel model)
		{
			var token = await generateJwtTokenService.JwtToken();

			var client = httpClientFactory.CreateClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",token);

			var response = await client.PostAsJsonAsync("https://localhost:44357/api/Registers", model);
			if (response.IsSuccessStatusCode)
			{
                var email = await response.Content.ReadAsStringAsync();

				return RedirectToAction("EmailConfimation", "EmailVerification", new { email = email});
			}
			return View();
		}
    }
}
