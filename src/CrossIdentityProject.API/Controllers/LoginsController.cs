using CrossIdentityProject.API.Entities;
using CrossIdentityProject.API.Models.IdentityModels;
using CrossIdentityProject.API.Services.ValidatorServices.LoginValidatorServices;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace CrossIdentityProject.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginsController : ControllerBase
	{
		private readonly SignInManager<AppUser> signInManager;
		private readonly UserManager<AppUser> userManager;
		private readonly ILoginValidatorService loginValidatorService;
		public LoginsController(SignInManager<AppUser> signInManager,
			   UserManager<AppUser> userManager,
			   ILoginValidatorService loginValidatorService)

		{
			this.signInManager = signInManager;
			this.userManager = userManager;
			this.loginValidatorService = loginValidatorService;
		}
		[HttpPost()]
		public async Task<IActionResult> SignIn([FromBody] LoginModel model)
		{
            ValidationResult validationResult = loginValidatorService.Validate(model);

            if (validationResult.IsValid)
			{
				var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: false, lockoutOnFailure: true);

				if (result.Succeeded)
				{
					var user_info = await userManager.FindByNameAsync(model.Username);

					var name = user_info!.Name;

					return Ok($"Login successful + {name}");
				}

				return Unauthorized("Invalid login attempt");
			}

			return Ok(validationResult.Errors.Select(x=>x.ErrorMessage));

		}

	}
}
