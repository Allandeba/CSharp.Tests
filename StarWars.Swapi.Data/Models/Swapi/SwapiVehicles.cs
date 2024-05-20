using System.Text.Json.Serialization;

namespace StarWars.Swapi.Data.Models.Swapi;

public class SwapiVehiclesResult : SwapiVehiclesResultBase
{
    [JsonPropertyName("vehicle_class")]
    public string VehicleClass { get; set; } = string.Empty;
}

public class SwapiVehicles : SwapiBase<SwapiVehiclesResult>;