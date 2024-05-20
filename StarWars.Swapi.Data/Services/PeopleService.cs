using System.Net.Http.Json;
using StarWars.Swapi.Data.Models.Swapi;

namespace StarWars.Swapi.Data.Services;

public interface IPeopleService
{
    Task<List<SwapiPeopleResult>> GetSwapiPeopleAsync();
    Task<List<SwapiPeopleResult>> GetSwapiPeopleAsync(IEnumerable<string> peopleUrls);
    Task<SwapiPeopleResult> GetSwapiPersonAsync(string peopleUrl);
}

public class PeopleService : BaseService, IPeopleService
{
    public async Task<List<SwapiPeopleResult>> GetSwapiPeopleAsync()
    {
        try
        {
            var peopleUrl = GetPeopleUrl();
            var swapiPeople = await client.GetFromJsonAsync<SwapiPeople>(peopleUrl);
            ValidateNullObject<SwapiFilms>(swapiPeople);

            return swapiPeople!.Results;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error on GetSwapiPeopleAsync()\n{e.InnerException}");
            throw;
        }
    }

    public async Task<List<SwapiPeopleResult>> GetSwapiPeopleAsync(IEnumerable<string> peopleUrls)
    {
        try
        {
            var result = new List<SwapiPeopleResult>();
            foreach (var peopleUrl in peopleUrls)
                result.Add(await GetSwapiPersonAsync(peopleUrl));

            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error on GetSwapiPeopleAsync(IEnumerable<string> peopleUrls)\n{e.InnerException}");
            throw;
        }
    }

    public async Task<SwapiPeopleResult> GetSwapiPersonAsync(string peopleUrl)
    {
        try
        {
            var result = await client.GetFromJsonAsync<SwapiPeopleResult>(peopleUrl);
            ValidateNullObject<SwapiPeopleResult>(result);

            return result!;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error on GetPersonAsync(string peopleUrl)\n{e.InnerException}");
            throw;
        }
    }
}