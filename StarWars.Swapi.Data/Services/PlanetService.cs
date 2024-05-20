using System.Net.Http.Json;
using StarWars.Swapi.Data.Models.Swapi;

namespace StarWars.Swapi.Data.Services;

public interface IPlanetsService
{
    Task<List<SwapiPlanetsResult>> GetSwapiPlanetsAsync();
    Task<List<SwapiPlanetsResult>> GetSwapiPlanetsAsync(IEnumerable<string> planetsUrls);
    Task<SwapiPlanetsResult> GetSwapiPlanetsAsync(string planetUrl);
}

public class PlanetsService : BaseService, IPlanetsService
{
    public async Task<List<SwapiPlanetsResult>> GetSwapiPlanetsAsync()
    {
        try
        {
            var planetsUrl = GetPlanetsUrl();
            var swapiPlanets = await client.GetFromJsonAsync<SwapiPlanets>(planetsUrl);
            ValidateNullObject<SwapiPlanets>(swapiPlanets);

            return swapiPlanets!.Results;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error on GetSwapiPlanetsAsync()\n{e.InnerException}");
            throw;
        }
    }

    public async Task<List<SwapiPlanetsResult>> GetSwapiPlanetsAsync(IEnumerable<string> planetsUrls)
    {
        try
        {
            var result = new List<SwapiPlanetsResult>();
            foreach (var planetUrl in planetsUrls)
                result.Add(await GetSwapiPlanetsAsync(planetUrl));

            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error on GetSwapiPlanetsAsync(IEnumerable<string> planetsUrls)\n{e.InnerException}");
            throw;
        }
    }

    public async Task<SwapiPlanetsResult> GetSwapiPlanetsAsync(string planetUrl)
    {
        try
        {
            var swapiPlanet = await client.GetFromJsonAsync<SwapiPlanetsResult>(planetUrl);
            ValidateNullObject<SwapiPlanetsResult>(swapiPlanet);

            return swapiPlanet!;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error on GetPlanetsAsync(string planetUrl)\n{e.InnerException}");
            throw;
        }
    }
}