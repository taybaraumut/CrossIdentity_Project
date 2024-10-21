using CrossIdentityProject.API.Models.IdentityModels;
using Microsoft.AspNetCore.Mvc;

namespace CrossIdentityProject.API.Services.IdentityServices.ChangePasswordServices
{
    public interface IChangePasswordService
    {
        public Task<string> ChangePasswordAsync(ChangePasswordModel model,string user); 
    }
}
