namespace StarWars.Swapi.Data.Models.MyTheFourth;

public class Planets : MyTheFourthBase
{
    public string Name { get; set; } = string.Empty;
    public double RotationPeriod { get; set; } = 0;
    public double OrbitalPeriod { get; set; } = 0;
    public double Diameter { get; set; } = 0;
    public string Climate { get; set; } = string.Empty;
    public string Gravity { get; set; } = string.Empty;
    public string Terrain { get; set; } = string.Empty;
    public string SurfaceWater { get; set; } = string.Empty;
    public string Population { get; set; } = string.Empty;
    public List<People> Residents { get; set; } = new();
    public List<Films> Films { get; set; } = new();
    public string Url { get; set; } = string.Empty;
    public string PlanetImageUrl { get; set; } = "https://img.freepik.com/free-photo/space-planet-science-night-generated-by-ai_188544-15619.jpg";
}