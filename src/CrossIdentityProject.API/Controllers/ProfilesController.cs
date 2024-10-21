using CrossIdentityProject.API.Entities;
using CrossIdentityProject.API.Models.IdentityModels;
using CrossIdentityProject.API.Services.IdentityServices.UserProfileInfoServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CrossIdentityProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IUserProfileInfoService userProfileInfoService;
        private readonly UserManager<AppUser> userManager;

        public ProfilesController(IUserProfileInfoService userProfileInfoService, UserManager<AppUser> userManager)
        {
            this.userProfileInfoService = userProfileInfoService;
            this.userManager = userManager;
        }

        [HttpGet("{user}")]
        public async Task<IActionResult> GetUserInfo(string user)
        {
            return Ok(await userProfileInfoService.ProfileInfoAsync(user));
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateUserInformation([FromBody] EditProfileModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await userProfileInfoService.ProfileInfoUpdateAsync(model));
            }
            return BadRequest("Validation Error");
        }
    }
}
