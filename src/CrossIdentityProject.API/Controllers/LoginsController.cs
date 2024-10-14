using CrossIdentityProject.API.Models.IdentityModels;
using CrossIdentityProject.API.Services.IdentityServices.LoginIdentityServices;
using CrossIdentityProject.API.Services.LogServices;
using CrossIdentityProject.API.Services.RandomCodeServices;
using Microsoft.AspNetCore.Mvc;

namespace CrossIdentityProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly ILoginIdentityService loginIdentityService;
        private readonly ILogService logService;

        public LoginsController(ILoginIdentityService loginIdentityService, ILogService logService)
        {
            this.loginIdentityService = loginIdentityService;
            this.logService = logService;
        }

        [HttpPost()]
        public async Task<IActionResult> SignIn([FromBody] LoginModel model)
        {
            return Ok(await loginIdentityService.LoginAsync(model));
        }
    }

}

