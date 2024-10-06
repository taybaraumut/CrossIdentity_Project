using CrossIdentityProject.API.Models.IdentityModels;
using FluentValidation.Results;

namespace CrossIdentityProject.API.Services.ValidatorServices.LoginValidatorServices
{
    public interface ILoginValidatorService
    {
        public Task<ValidationResult> Validate(LoginModel model);
        
    }
}
