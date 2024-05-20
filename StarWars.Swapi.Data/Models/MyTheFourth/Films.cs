namespace StarWars.Swapi.Data.Models.MyTheFourth;

public class Films
{
    public string Title { get; set; } = string.Empty;
    public int EpisodeId { get; set; } = 0;
    public string OpeningCrawl { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public string Producer { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; } = DateTime.MinValue;
    public List<People> Characters { get; set; } = new();
    public List<Planets> Planets { get; set; } = new();
    public List<Species> Species { get; set; } = new();
    public List<Vehicles> Vehicles { get; set; } = new();
    public List<Starships> Starships { get; set; } = new();
}