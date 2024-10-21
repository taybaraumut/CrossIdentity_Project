using Bogus;
using CrossIdentityProject.API.Models.CityModels;
using Microsoft.AspNetCore.Authorization;

namespace CrossIdentityProject.API.Extensions.MinimalApiExtensions
{
    public static class MinimalApiServiceExtension
    {
        public static IEndpointRouteBuilder UseMinimalApiHandler(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapGet("/api/minimal_api/GetCities",[Authorize]() =>
            {
                var cities = new Faker<CityModel>()
                                    .RuleFor(cities => cities.CityID, x => x.IndexFaker + 1)
                                    .RuleFor(cities => cities.CityName, x => x.Address.Country())
                                    .Generate(40)
                                    .ToList();

                return cities;
            });

            return endpointRouteBuilder;
        }
    }
}
