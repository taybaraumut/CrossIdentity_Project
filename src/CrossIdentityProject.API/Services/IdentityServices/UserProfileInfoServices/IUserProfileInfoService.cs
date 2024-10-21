using CrossIdentityProject.API.Models;
using CrossIdentityProject.API.Models.IdentityModels;
using Microsoft.AspNetCore.Mvc;

namespace CrossIdentityProject.API.Services.IdentityServices.UserProfileInfoServices
{
    public interface IUserProfileInfoService
    {
        public Task<object> ProfileInfoAsync(string user);
        public Task<string> ProfileInfoUpdateAsync(EditProfileModel model);
    }
}
