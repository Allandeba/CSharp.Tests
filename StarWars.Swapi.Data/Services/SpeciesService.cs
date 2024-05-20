using System.Net.Http.Json;
using StarWars.Swapi.Data.Models.Swapi;

namespace StarWars.Swapi.Data.Services;

public interface ISpeciesService
{
    Task<List<SwapiSpeciesResult>> GetSwapiSpeciesAsync();
    Task<List<SwapiSpeciesResult>> GetSwapiSpeciesAsync(IEnumerable<string> speciesUrls);
    Task<SwapiSpeciesResult> GetSwapiSpecieAsync(string specieUrl);
}

public class SpeciesService : BaseService, ISpeciesService
{
    public async Task<List<SwapiSpeciesResult>> GetSwapiSpeciesAsync()
    {
        try
        {
            var speciesUrl = GetSpeciesUrl();
            var swapiSpecies = await client.GetFromJsonAsync<SwapiSpecies>(speciesUrl);
            ValidateNullObject<SwapiSpecies>(swapiSpecies);

            return swapiSpecies!.Results;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error on GetSwapiSpeciesAsync()\n{e.InnerException}");
            throw;
        }
    }

    public async Task<List<SwapiSpeciesResult>> GetSwapiSpeciesAsync(IEnumerable<string> speciesUrls)
    {
        try
        {
            var result = new List<SwapiSpeciesResult>();
            foreach (var specieUrl in speciesUrls)
                result.Add(await GetSwapiSpecieAsync(specieUrl));

            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error on GetSwapiSpeciesAsync(IEnumerable<string> speciesUrls)\n{e.InnerException}");
            throw;
        }
    }

    public async Task<SwapiSpeciesResult> GetSwapiSpecieAsync(string specieUrl)
    {
        try
        {
            var swapiSpecie = await client.GetFromJsonAsync<SwapiSpeciesResult>(specieUrl);
            ValidateNullObject<SwapiSpeciesResult>(swapiSpecie);

            return swapiSpecie!;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error on GetSwapiSpecieAsync(string specieUrl)\n{e.InnerException}");
            throw;
        }
    }
}