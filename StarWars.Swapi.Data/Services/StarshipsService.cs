using System.Net.Http.Json;
using StarWars.Swapi.Data.Models.Swapi;

namespace StarWars.Swapi.Data.Services;

public interface IStarshipsService
{
    Task<List<SwapiStarshipsResult>> GetSwapiStarshipsAsync();
    Task<List<SwapiStarshipsResult>> GetSwapiStarshipsAsync(IEnumerable<string> starshipsUrls);
    Task<SwapiStarshipsResult> GetSwapiStarshipAsync(string starshipUrl);
}

public class StarshipsService : BaseService, IStarshipsService
{
    public async Task<List<SwapiStarshipsResult>> GetSwapiStarshipsAsync()
    {
        try
        {
            var starshipsUrl = GetStarshipsUrl();
            var swapiStarships = await client.GetFromJsonAsync<SwapiStarships>(starshipsUrl);
            ValidateNullObject<SwapiStarships>(swapiStarships);

            return swapiStarships!.Results;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error on GetSwapiStarshipsAsync()\n{e.InnerException}");
            throw;
        }
    }

    public async Task<List<SwapiStarshipsResult>> GetSwapiStarshipsAsync(IEnumerable<string> starshipsUrls)
    {
        try
        {
            var result = new List<SwapiStarshipsResult>();
            foreach (var starshipUrl in starshipsUrls)
                result.Add(await GetSwapiStarshipAsync(starshipUrl));

            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error on GetSwapiStarshipsAsync(IEnumerable<string> starshipsUrls)\n{e.InnerException}");
            throw;
        }
    }

    public async Task<SwapiStarshipsResult> GetSwapiStarshipAsync(string starshipUrl)
    {
        try
        {
            var swapiStarship = await client.GetFromJsonAsync<SwapiStarshipsResult>(starshipUrl);
            ValidateNullObject<SwapiStarshipsResult>(swapiStarship);

            return swapiStarship!;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error on GetSwapiStarshipAsync(string starshipUrl)\n{e.InnerException}");
            throw;
        }
    }
}