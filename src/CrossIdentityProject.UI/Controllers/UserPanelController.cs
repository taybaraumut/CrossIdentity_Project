using Microsoft.AspNetCore.Mvc;

namespace CrossIdentityProject.UI.Controllers
{
    public class UserPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult ProfilePassword()
        {
            return View();
        }
    }
}
