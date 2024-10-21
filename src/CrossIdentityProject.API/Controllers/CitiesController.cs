using Bogus;
using CrossIdentityProject.API.Models.CityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrossIdentityProject.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {       
        [HttpGet]
        public IActionResult Get()
        {
            var cities = new Faker<CityModel>()
                                    .RuleFor(cities => cities.CityID, x => x.IndexFaker + 1)
                                    .RuleFor(cities => cities.CityName, x => x.Address.Country())
                                    .Generate(40)
                                    .ToList();

            return Ok(cities);
        }
    }
}
