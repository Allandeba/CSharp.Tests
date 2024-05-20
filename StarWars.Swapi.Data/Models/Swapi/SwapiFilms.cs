using System.Text.Json.Serialization;

namespace StarWars.Swapi.Data.Models.Swapi;

public class SwapiFilmsResult
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("episode_id")]
    public int EpisodeId { get; set; } = 0;

    [JsonPropertyName("opening_crawl")]
    public string OpeningCrawl { get; set; } = string.Empty;

    [JsonPropertyName("director")]
    public string Director { get; set; } = string.Empty;

    [JsonPropertyName("producer")]
    public string Producer { get; set; } = string.Empty;

    [JsonPropertyName("release_date")]
    public DateTime ReleaseDate { get; set; } = DateTime.MinValue;

    [JsonPropertyName("characters")]
    public List<string> Characters { get; set; } = new();

    [JsonPropertyName("planets")]
    public List<string> Planets { get; set; } = new();

    [JsonPropertyName("species")]
    public List<string> Species { get; set; } = new();

    [JsonPropertyName("vehicles")]
    public List<string> Vehicles { get; set; } = new();

    [JsonPropertyName("starships")]
    public List<string> Starships { get; set; } = new();
}

public class SwapiFilms : SwapiBase<SwapiFilmsResult>;