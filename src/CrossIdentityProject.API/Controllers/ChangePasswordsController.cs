using CrossIdentityProject.API.Entities;
using CrossIdentityProject.API.Models.IdentityModels;
using CrossIdentityProject.API.Services.IdentityServices.ChangePasswordServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrossIdentityProject.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChangePasswordsController : ControllerBase
    {
        private readonly IChangePasswordService changePasswordService;

        public ChangePasswordsController(IChangePasswordService changePasswordService)
        {
            this.changePasswordService = changePasswordService;
        }

        [HttpPost()]
        public async Task<IActionResult> PasswordChange([FromBody]ChangePasswordModel model, [FromQuery] string user)
        {
            return Ok(await changePasswordService.ChangePasswordAsync(model,user));
        }
    }
}
