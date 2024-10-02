using CrossIdentityProject.UI.Models.IdentityViewModels;
using FluentValidation.Results;

namespace CrossIdentityProject.UI.Services.ValidatorServices.RegisterValidatorServices
{
    public interface IRegisterValidatorService
    {
        ValidationResult Validate(RegisterViewModel model);
    }
}
