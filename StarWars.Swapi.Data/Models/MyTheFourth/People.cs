namespace StarWars.Swapi.Data.Models.MyTheFourth;

public class People : MyTheFourthBase
{
    public string Name { get; set; } = string.Empty; 
    public double Height { get; set; } = 0;
    public double Mass { get; set; } = 0;
    public string HairColor { get; set; } = string.Empty; 
    public string SkinColor { get; set; } = string.Empty; 
    public string EyeColor { get; set; } = string.Empty; 
    public string Birth_year { get; set; } = string.Empty; 
    public string Gender { get; set; } = string.Empty; 
    public Planets Homeworld { get; set; } = new();
    public List<Films> Movies { get; set; } = new();
    public List<Species> Species { get; set; } = new();
    public List<Vehicles> Vehicles { get; set; } = new();
    public List<Starships> Starships { get; set; } = new();
    public string PeopleImageUrl { get; set; } = "https://img.freepik.com/free-vector/isolated-young-handsome-man-different-poses-white-background-illustration_632498-857.jpg";
}