namespace StarWars.Swapi.Data.Models.MyTheFourth;


public class Starships : StarshipVehicle
{
    public double HyperdriveRating { get; set; } = 0;
    public int MGLT { get; set; } = 0;
    public string StarshipClass { get; set; } = string.Empty;
    public string StarshipImageUrl { get; set; } = "https://img.freepik.com/free-vector/cute-astronaut-riding-rocket-waving-hand-cartoon-icon-illustration-science-technology-icon-concept_138676-2130.jpg?t=st=1716250307~exp=1716250907~hmac=85c307a9eb3f2c95b888ebb542d027344e889f61e4534f6fe139588b8490edfd";
}