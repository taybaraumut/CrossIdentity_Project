using CrossIdentityProject.UI.Models.CityModels;

namespace CrossIdentityProject.UI.Services.CityServices
{
    public interface ICityService
    {
        public Task<List<CityModel>> GetCities();
    }
}
