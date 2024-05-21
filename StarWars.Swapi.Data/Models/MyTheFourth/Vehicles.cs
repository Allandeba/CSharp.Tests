namespace StarWars.Swapi.Data.Models.MyTheFourth;

public class Vehicles : StarshipVehicle
{
    public string VehicleClass { get; set; } = string.Empty;

    public Vehicles()
    {
        ImgUrl = "https://img.freepik.com/free-vector/sticker-template-with-satellite-cartoon-style-isolated_1308-62857.jpg";
    }
}