using System.Text.Json;
using StarWars.Swapi.Data.Models.Swapi;

namespace StarWars.Swapi.Data.Services;

public interface IBaseService
{
    public void ValidateNullObject<T>(Object? _object);
    public string GetFilmsUrl();
    public string GetPeopleUrl();
    public string GetPlanetsUrl();
    public string GetSpeciesUrl();
    public string GetStarshipsUrl();
    public string GetVehiclesUrl();
}

public class BaseService : IBaseService
{
    private const string Url = "https://swapi.dev/api/";

    protected readonly HttpClient client = new HttpClient();

    private async Task<SwapiRoot> GetRootAsync()
    {
        var json = await client.GetStringAsync(Url);
        var swapiRoot = JsonSerializer.Deserialize<SwapiRoot>(json);
        ValidateNullObject<SwapiRoot>(swapiRoot);

        return swapiRoot!;
    }

    public void ValidateNullObject<T>(Object? _object)
    {
        if (_object == null)
            throw new NullReferenceException($"Objeto {typeof(T).Name} não foi convertido com sucesso!");
    }

    public string GetFilmsUrl() => GetRootAsync().GetAwaiter().GetResult().Films;
    public string GetPeopleUrl() => GetRootAsync().GetAwaiter().GetResult().People;
    public string GetPlanetsUrl() => GetRootAsync().GetAwaiter().GetResult().Planets;
    public string GetSpeciesUrl() => GetRootAsync().GetAwaiter().GetResult().Species;
    public string GetStarshipsUrl() => GetRootAsync().GetAwaiter().GetResult().Starships;
    public string GetVehiclesUrl() => GetRootAsync().GetAwaiter().GetResult().Vehicles;
}