using System.Net.Http.Json;
using StarWars.Swapi.Data.Models.Swapi;

namespace StarWars.Swapi.Data.Services;

public interface IVehiclesService
{
    Task<List<SwapiVehiclesResult>> GetSwapiVehiclesAsync();
    Task<List<SwapiVehiclesResult>> GetSwapiVehiclesAsync(IEnumerable<string> vehiclesUrls);
    Task<SwapiVehiclesResult> GetSwapiVehicleAsync(string vehicleUrl);
}

public class VehiclesService : BaseService, IVehiclesService
{
    public async Task<List<SwapiVehiclesResult>> GetSwapiVehiclesAsync()
    {
        try
        {
            var vehiclesUrl = GetVehiclesUrl();
            var swapiVehicles = await client.GetFromJsonAsync<SwapiVehicles>(vehiclesUrl);
            ValidateNullObject<SwapiVehicles>(swapiVehicles);

            return swapiVehicles!.Results;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error on GetSwapiVehiclesAsync()\n{e.InnerException}");
            throw;
        }
    }

    public async Task<List<SwapiVehiclesResult>> GetSwapiVehiclesAsync(IEnumerable<string> vehiclesUrls)
    {
        try
        {
            var result = new List<SwapiVehiclesResult>();
            foreach (var vehicleUrl in vehiclesUrls)
                result.Add(await GetSwapiVehicleAsync(vehicleUrl));

            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error on GetSwapiVehiclesAsync(IEnumerable<string> vehiclesUrls)\n{e.InnerException}");
            throw;
        }
    }

    public async Task<SwapiVehiclesResult> GetSwapiVehicleAsync(string vehicleUrl)
    {
        try
        {
            var swapiVehicle = await client.GetFromJsonAsync<SwapiVehiclesResult>(vehicleUrl);
            ValidateNullObject<SwapiVehiclesResult>(swapiVehicle);

            return swapiVehicle!;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error on GetSwapiVehicleAsync(string vehicleUrl)\n{e.InnerException}");
            throw;
        }
    }
}