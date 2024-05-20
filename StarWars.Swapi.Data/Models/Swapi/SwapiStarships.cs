using System.Text.Json.Serialization;

namespace StarWars.Swapi.Data.Models.Swapi;

public class SwapiStarshipsResult : SwapiVehiclesResultBase
{
    [JsonPropertyName("hyperdrive_rating")]
    public string HyperdriveRating { get; set; } = string.Empty;

    [JsonPropertyName("MGLT")]
    public string MGLT { get; set; } = string.Empty;
    
    [JsonPropertyName("starship_class")]
    public string StarshipClass { get; set; } = string.Empty;
}

public class SwapiStarships : SwapiBase<SwapiStarshipsResult>;