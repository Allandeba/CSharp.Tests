using System.Text.Json.Serialization;

namespace StarWars.Swapi.Data.Models.Swapi;

public class SwapiVehiclesResultBase
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    [JsonPropertyName("model")]
    public string Model { get; set; } = string.Empty;
    
    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; set; } = string.Empty;
    
    [JsonPropertyName("cost_in_credits")]
    public string CostInCredits { get; set; } = string.Empty;
    
    [JsonPropertyName("length")]
    public string Length { get; set; } = string.Empty;
    
    [JsonPropertyName("max_atmosphering_speed")]
    public string MaxAtmospheringSpeed { get; set; } = string.Empty;
    
    [JsonPropertyName("crew")]
    public string Crew { get; set; } = string.Empty;
    
    [JsonPropertyName("passengers")]
    public string Passangers { get; set; } = string.Empty;
    
    [JsonPropertyName("cargo_capacity")]
    public string Cargo_capacity { get; set; } = string.Empty;
    
    [JsonPropertyName("consumables")]
    public string Consumables { get; set; } = string.Empty;
    
    [JsonPropertyName("pilots")]
    public List<string> Pilots { get; set; } = new();
    
    [JsonPropertyName("films")]
    public List<string> Movies { get; set; } = new();
}