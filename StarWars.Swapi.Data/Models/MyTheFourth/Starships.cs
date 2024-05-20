namespace StarWars.Swapi.Data.Models.MyTheFourth;

public class Starships : StarshipVehicle
{
    public double HyperdriveRating { get; set; } = 0;
    public int MGLT { get; set; } = 0;
    public string StarshipClass { get; set; } = string.Empty;
}