using CrossIdentityProject.API.Entities;
using CrossIdentityProject.API.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace CrossIdentityProject.API.Services.IdentityServices.UserProfileInfoServices
{
    public class UserProfileInfoService : IUserProfileInfoService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public UserProfileInfoService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<object> ProfileInfoAsync(string user)
        {
            try
            {
                var get_user = await userManager.FindByNameAsync(user);

                if (get_user != null)
                {
                    var user_Id = get_user.Id;
                    var name = get_user.Name;
                    var surname = get_user.Surname;
                    var username = get_user.UserName;
                    var email = get_user.Email;
                    var city = get_user.City;
                    var district = get_user.District;
                    var two_factor = get_user.TwoFactorEnabled;

                    return new
                    {
                        Id = user_Id,
                        Name = name,
                        Surname = surname,
                        UserName = username,
                        Email = email,
                        City = city,
                        District = district,
                        TwoFactor = two_factor,
                    };

                }
                throw new NotImplementedException("User Not Found");
            }
            catch (Exception ex)
            {
                return new {ErrorMessage =  ex.Message};
            }           
        }

        public async Task<string> ProfileInfoUpdateAsync(EditProfileModel model)
        {
            try
            {
                var get_user = await userManager.FindByIdAsync(model.Id);
                get_user!.Name = model.Name;
                get_user!.Surname = model.Surname;
                get_user!.UserName = model.UserName;
                get_user!.Email = model.Email;
                get_user!.City = model.City;
                get_user!.District = model.District;
                get_user.TwoFactorEnabled = model.TwoFactor;

                var result = await userManager.UpdateAsync(get_user);

                if (result.Succeeded)
                {
                    await userManager.UpdateSecurityStampAsync(get_user);
                    await signInManager.SignOutAsync();

                    return "Success";
                }

                throw new Exception("System Error");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
