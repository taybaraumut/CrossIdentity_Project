using CrossIdentityProject.UI.Models.ProfileModels;
using CrossIdentityProject.UI.Services.CityServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using CrossIdentityProject.UI.Models.IdentityViewModels;
using CrossIdentityProject.UI.Services.GenerateJwtTokenServices;
using System.Net.Http.Headers;

namespace CrossIdentityProject.UI.Controllers
{
    [Authorize]
    public class UserPanelController : Controller
    {
        private readonly ICityService cityService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IGenerateJwtTokenService generateJwtTokenService;

        public UserPanelController(ICityService cityService, IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory, IGenerateJwtTokenService generateJwtTokenService)
        {
            this.cityService = cityService;
            this.httpContextAccessor = httpContextAccessor;
            this.httpClientFactory = httpClientFactory;
            this.generateJwtTokenService = generateJwtTokenService;
        }

        public async Task<IActionResult> Index()
        {
            var cities = await cityService.GetCities();
            return View(cities);
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {

            var user = httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.Name);
            var client = httpClientFactory.CreateClient();


            var response = await client.GetAsync($"https://localhost:44357/api/Profiles/{user}");
            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                var jsondata = JsonConvert.DeserializeObject<ProfileModel>(body);
                return View(jsondata);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Profile(EditProfileModel model)
        {
            var token = await generateJwtTokenService.JwtToken();
            var client = httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await client.PutAsJsonAsync("https://localhost:44357/api/Profiles", model);

            if (response.IsSuccessStatusCode)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("SignIn", "Login");
            }

            return RedirectToAction("Profile");
        }
        [HttpGet]
        public IActionResult ProfilePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProfilePassword(ChangePasswordViewModel model)
        {
            var token = await generateJwtTokenService.JwtToken();
            var user = HttpContext.User.FindFirstValue(ClaimTypes.Name);

            var client = httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            var response = await client.PostAsJsonAsync($"https://localhost:44357/api/ChangePasswords?user={user}", model);

            if (response.IsSuccessStatusCode)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("SignIn", "Login");
            }

            return RedirectToAction("ProfilePassword");
        }


    }
}
