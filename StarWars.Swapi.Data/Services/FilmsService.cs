using System.Net.Http.Json;
using StarWars.Swapi.Data.Models.Swapi;

namespace StarWars.Swapi.Data.Services;

public interface IFilmsService
{
    Task<List<SwapiFilmsResult>> GetSwapiFilmsAsync();
    Task<List<SwapiFilmsResult>> GetSwapiFilmsAsync(IEnumerable<string> filmsUrls);
    Task<SwapiFilmsResult> GetSwapiFilmAsync(string filmUrl);
}

public class FilmsService : BaseService, IFilmsService
{
    public async Task<List<SwapiFilmsResult>> GetSwapiFilmsAsync()
    {
        try
        {
            var filmsUrl = GetFilmsUrl();
            var swapiFilms = await client.GetFromJsonAsync<SwapiFilms>(filmsUrl);
            ValidateNullObject<SwapiFilms>(swapiFilms);

            return swapiFilms!.Results;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error on GetSwapiFilmsAsync()\n{e.InnerException}");
            throw;
        }
    }

    public async Task<List<SwapiFilmsResult>> GetSwapiFilmsAsync(IEnumerable<string> filmsUrls)
    {
        try
        {
            var result = new List<SwapiFilmsResult>();
            foreach (var filmUrl in filmsUrls)
                result.Add(await GetSwapiFilmAsync(filmUrl));

            return result!;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error on GetSwapiFilmsAsync()\n{e.InnerException}");
            throw;
        }
    }

    public async Task<SwapiFilmsResult> GetSwapiFilmAsync(string filmUrl)
    {
        try
        {
            var result = await client.GetFromJsonAsync<SwapiFilmsResult>(filmUrl);
            ValidateNullObject<SwapiFilmsResult>(result);

            return result!;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error on GetFilmAsync(string filmUrl)\n{e.InnerException}");
            throw;
        }
    }
}