namespace StarWars.Swapi.Data.Models.MyTheFourth;

public class Species
{
    public string Name { get; set; } = string.Empty;
    public string Classification { get; set; } = string.Empty;
    public string Designation { get; set; } = string.Empty;
    public int AvarageHeight { get; set; } = 0;
    public string SkinColors { get; set; } = string.Empty;
    public string HairColors { get; set; } = string.Empty;
    public string EyeColors { get; set; } = string.Empty;
    public int AvarageLifespan { get; set; } = 0;
    public Planets Homeworld { get; set; } = new();
    public string Language { get; set; } = string.Empty;
    public List<People> People { get; set; } = new();
    public List<Films> Movies { get; set; } = new();
    public string SpecieImageUrl { get; set; } = "https://img.freepik.com/free-photo/medium-shot-alien-monochrome_23-2151444790.jpg";
}