using CrossIdentityProject.API.Entities;
using CrossIdentityProject.API.Models.IdentityModels;
using CrossIdentityProject.API.Services.ValidatorServices.RegisterValidatorServices;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CrossIdentityProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IRegisterValidatorService registerValidatorService;

        public RegistersController(UserManager<AppUser> userManager,
               IRegisterValidatorService registerValidatorService)
        {
            this.userManager = userManager;
            this.registerValidatorService = registerValidatorService;
        }
        [HttpPost()]
        public async Task<IActionResult> SignUp([FromBody] RegisterModel model)
        {
            ValidationResult validationResult = registerValidatorService.Validate(model);

            if (validationResult.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    UserName = model.Username,
                    Email = model.Email,
                    City = model.City,
                    District = model.District,
                    Code = 62,
                };

                var create_user = await userManager.CreateAsync(user, model.Password);

                if (create_user.Succeeded)
                {
                    return Ok("Başarılı");
                }
            }

            return Ok(validationResult.Errors.Select(x=>x.ErrorMessage));

        }
    }
}
