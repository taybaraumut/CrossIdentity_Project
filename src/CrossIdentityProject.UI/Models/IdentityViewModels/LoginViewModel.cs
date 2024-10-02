using CrossIdentityProject.UI.ValidationRules.IdentityValidationRules;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace CrossIdentityProject.UI.Models.IdentityViewModels
{
	public class LoginViewModel
	{
		public string? Username { get; set; }
		public string? Password { get; set; }
	}
}
