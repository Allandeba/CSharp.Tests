using System.Text.Json.Serialization;

namespace StarWars.Swapi.Data.Models.Swapi;

public class SwapiSpeciesResult
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    [JsonPropertyName("classification")]
    public string Classification { get; set; } = string.Empty;
    
    [JsonPropertyName("designation")]
    public string Designation { get; set; } = string.Empty;
    
    [JsonPropertyName("average_height")]
    public string AvarageHeight { get; set; } = string.Empty;
    
    [JsonPropertyName("skin_colors")]
    public string SkinColors { get; set; } = string.Empty;
    
    [JsonPropertyName("hair_colors")]
    public string HairColors { get; set; } = string.Empty;
    
    [JsonPropertyName("eye_colors")]
    public string EyeColors { get; set; } = string.Empty;
    
    [JsonPropertyName("average_lifespan")]
    public string AvarageLifespan { get; set; } = string.Empty;
    
    [JsonPropertyName("homeworld")]
    public string Homeworld { get; set; } = string.Empty;
    
    [JsonPropertyName("language")]
    public string Language { get; set; } = string.Empty;
    
    [JsonPropertyName("people")]
    public List<string> People { get; set; } = new();
    
    [JsonPropertyName("films")]
    public List<string> Movies { get; set; } = new();
}

public class SwapiSpecies : SwapiBase<SwapiSpeciesResult>;