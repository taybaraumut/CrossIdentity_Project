using CrossIdentityProject.UI.Models.IdentityViewModels;
using FluentValidation;

namespace CrossIdentityProject.UI.ValidationRules.IdentityValidationRules
{
	public class LoginValidator:AbstractValidator<LoginViewModel>
	{
        public LoginValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("kullanıcı adı boş geçilemez")
                .MinimumLength(6).WithMessage("kullanıcı adı en az 6 karakter olabilir")
                .MaximumLength(15).WithMessage("kullanıcı adı en fazla 15 karakter olabilir");

            RuleFor(x => x.Password).NotNull().WithMessage("şifre boş geçilemez");
        }
    }
}

