using CrossIdentityProject.UI.Models.IdentityViewModels;
using FluentValidation.Results;

namespace CrossIdentityProject.UI.Services.ValidatorServices.LoginValidatorServices
{
    public interface ILoginValidatorService
    {
		ValidationResult Validate(LoginViewModel model);
	}
}
