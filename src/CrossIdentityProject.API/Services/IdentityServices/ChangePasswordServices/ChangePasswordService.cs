using CrossIdentityProject.API.Entities;
using CrossIdentityProject.API.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace CrossIdentityProject.API.Services.IdentityServices.ChangePasswordServices
{
    public class ChangePasswordService : IChangePasswordService
    {
        private readonly UserManager<AppUser> userManager;

        public ChangePasswordService(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<string> ChangePasswordAsync(ChangePasswordModel model, string user)
        {
            try
            {
                var user_info = await userManager.FindByNameAsync(user);

                if (user_info != null)
                {
                    var change = await userManager.ChangePasswordAsync(user_info, model.CurrentPassword, model.NewPassword);
                    if (change.Succeeded)
                    {
                        return "Success";
                    }
                    throw new NotImplementedException("Old Password is Incorrect");
                }
                throw new NotImplementedException("User Not Found");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }           
        }
    }
}
