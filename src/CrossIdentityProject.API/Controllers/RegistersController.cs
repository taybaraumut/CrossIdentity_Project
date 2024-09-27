using CrossIdentityProject.API.Entities;
using CrossIdentityProject.API.Models.IdentityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CrossIdentityProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;

        public RegistersController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost()]
        public async Task<IActionResult> SignUp([FromBody] RegisterModel registerModel)
        {
            AppUser user = new AppUser()
            {
                Name = registerModel.Name,
                Surname = registerModel.Surname,
                UserName = registerModel.UserName,
                Email = registerModel.Email,
                City = registerModel.City,
                District = registerModel.District,
                Code = 62,            
            }; 

            var create_user = await userManager.CreateAsync(user,registerModel.Password);

            if (create_user.Succeeded)
            {
                return Ok("Başarılı");
            }

            return Ok();
        }
    }
}
