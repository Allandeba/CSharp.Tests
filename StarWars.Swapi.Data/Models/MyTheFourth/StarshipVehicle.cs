namespace StarWars.Swapi.Data.Models.MyTheFourth;

public class StarshipVehicle : MyTheFourthBase
{
    public string Name { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public string CostInCredits { get; set; } = string.Empty;
    public double Length { get; set; } = 0;
    public int MaxAtmospheringSpeed { get; set; } = 0;
    public int Crew { get; set; } = 0;
    public int Passangers { get; set; } = 0;
    public int Cargo_capacity { get; set; } = 0;
    public string Consumables { get; set; } = string.Empty;
    public List<People> Pilots { get; set; } = new();
    public List<Films> Movies { get; set; } = new();
}