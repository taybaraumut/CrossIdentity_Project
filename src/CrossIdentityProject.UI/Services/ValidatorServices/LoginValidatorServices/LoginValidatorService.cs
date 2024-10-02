using CrossIdentityProject.UI.Models.IdentityViewModels;
using FluentValidation;
using FluentValidation.Results;

namespace CrossIdentityProject.UI.Services.ValidatorServices.LoginValidatorServices
{
	public class LoginValidatorService : ILoginValidatorService
	{
		private readonly IValidator<LoginViewModel> validator;

		public LoginValidatorService(IValidator<LoginViewModel> validator)
		{
			this.validator = validator;
		}

		public ValidationResult Validate(LoginViewModel model)
		{
			return validator.Validate(model);
		}
    }
}
