using System.Text.Json;
using StarWars.Swapi.Data.Models.MyTheFourth;

namespace StarWars.Swapi.Data.Services;

public interface ISwapiService
{
    Task SaveAllJsonAsync();
}

public class SwapiService : BaseService, ISwapiService
{
    private readonly IPlanetsService _planetsService;
    private readonly IFilmsService _filmsService;
    private readonly IPeopleService _peopleService;
    private readonly ISpeciesService _speciesService;
    private readonly IStarshipsService _starshipsService;
    private readonly IVehiclesService _vehiclesService;

    public SwapiService(IPlanetsService planetsService, IFilmsService filmsService, IPeopleService peopleService, 
        ISpeciesService speciesService, IStarshipsService starshipsService, IVehiclesService vehiclesService)
    {
        _planetsService = planetsService;
        _filmsService = filmsService;
        _peopleService = peopleService;
        _speciesService = speciesService;
        _starshipsService = starshipsService;
        _vehiclesService = vehiclesService;
        
    }
    public async Task SaveAllJsonAsync()
    {
        await SaveFilmsAsync();
        await SavePeopleAsync();
        await SaveSpeciesAsync();
        await SaveStarshipsAsync();
        await SaveVehiclesAsync();
        return;
    }

    private async Task SaveFilmsAsync()
    {
        var films = await _filmsService.GetSwapiFilmsAsync();
        var filmsFinal = new List<Films>();
        var tasks = new List<Task>();

        foreach (var swapiFilm in films)
        {
            var film = SwapiMapper.Mapper.Map<Films>(swapiFilm);

            var fillTasks = new List<Task>
            {
                FillPeopleAsync(swapiFilm.Characters, film.Characters),
                FillPlanetsAsync(swapiFilm.Planets, film.Planets),
                FillSpeciesAsync(swapiFilm.Species, film.Species),
                FillStarshipsAsync(swapiFilm.Starships, film.Starships),
                FillVehiclesAsync(swapiFilm.Vehicles, film.Vehicles)
            };

            tasks.Add(Task.WhenAll(fillTasks).ContinueWith(t => filmsFinal.Add(film)));
        }

        await Task.WhenAll(tasks);

        SaveJsonFile<Films>(filmsFinal, "films");
    }

    private async Task SavePeopleAsync()
    {
        var people = await _peopleService.GetSwapiPeopleAsync();
        var peopleFinal = new List<People>();
        var tasks = new List<Task>();

        foreach (var swapiPeople in people)
        {
            var person = SwapiMapper.Mapper.Map<People>(swapiPeople);

            var fillTasks = new List<Task>
            {
                FillSpeciesAsync(swapiPeople.Species, person.Species),
                FillStarshipsAsync(swapiPeople.Starships, person.Starships),
                FillVehiclesAsync(swapiPeople.Vehicles, person.Vehicles)
            };

            tasks.Add(Task.WhenAll(fillTasks).ContinueWith(t => peopleFinal.Add(person)));
        }

        await Task.WhenAll(tasks);

        SaveJsonFile<People>(peopleFinal, "people");
    }

    private async Task SaveSpeciesAsync()
    {
        var species = await _speciesService.GetSwapiSpeciesAsync();
        var speciesFinal = new List<Species>();
        var tasks = new List<Task>();

        foreach (var swapispecies in species)
        {
            var specie = SwapiMapper.Mapper.Map<Species>(swapispecies);

            var fillTasks = new List<Task>
            {
                FillPeopleAsync(swapispecies.People, specie.People),
                FillFilmsAsync(swapispecies.Movies, specie.Movies),
            };

            tasks.Add(Task.WhenAll(fillTasks).ContinueWith(t => speciesFinal.Add(specie)));
        }

        await Task.WhenAll(tasks);

        SaveJsonFile<Species>(speciesFinal, "species");
    }

    private async Task SaveStarshipsAsync() 
    {
        var starships = await _starshipsService.GetSwapiStarshipsAsync();
        var starshipsFinal = new List<Starships>();
        var tasks = new List<Task>();

        foreach (var swapiStarship in starships)
        {
            var starship = SwapiMapper.Mapper.Map<Starships>(swapiStarship);

            var fillTasks = new List<Task>
            {
                FillPeopleAsync(swapiStarship.Pilots, starship.Pilots),
                FillFilmsAsync(swapiStarship.Movies, starship.Movies),
            };

            tasks.Add(Task.WhenAll(fillTasks).ContinueWith(t => starshipsFinal.Add(starship)));
        }

        await Task.WhenAll(tasks);

        SaveJsonFile<Starships>(starshipsFinal, "starships");
    }

    private async Task SaveVehiclesAsync()
    {
        var vehicles = await _vehiclesService.GetSwapiVehiclesAsync();
        var vehiclesFinal = new List<Vehicles>();
        var tasks = new List<Task>();

        foreach (var swapiVehicle in vehicles)
        {
            var vehicle = SwapiMapper.Mapper.Map<Vehicles>(swapiVehicle);

            var fillTasks = new List<Task>
            {
                FillPeopleAsync(swapiVehicle.Pilots, vehicle.Pilots),
                FillFilmsAsync(swapiVehicle.Movies, vehicle.Movies),
            };

            tasks.Add(Task.WhenAll(fillTasks).ContinueWith(t => vehiclesFinal.Add(vehicle)));
        }

        await Task.WhenAll(tasks);

        SaveJsonFile<Vehicles>(vehiclesFinal, "vehicles");
    }

    private async Task FillPeopleAsync(List<string> peopleUrl, List<People> people)
    {
        var swapiPeople = await _peopleService.GetSwapiPeopleAsync(peopleUrl);
        people.AddRange(swapiPeople.Select(person => SwapiMapper.Mapper.Map<People>(person)));
    }

    private async Task FillPlanetsAsync(List<string> planetsUrl, List<Planets> planets)
    {
        var swapiPlanets = await _planetsService.GetSwapiPlanetsAsync(planetsUrl);
        planets.AddRange(swapiPlanets.Select(planet => SwapiMapper.Mapper.Map<Planets>(planet)));
    }

    private async Task FillSpeciesAsync(List<string> speciesUrl, List<Species> species)
    {
        var swapiSpecies = await _speciesService.GetSwapiSpeciesAsync(speciesUrl);
        species.AddRange(swapiSpecies.Select(specie => SwapiMapper.Mapper.Map<Species>(specie)));
   }

    private async Task FillStarshipsAsync(List<string> starshipsUrl, List<Starships> starships)
    {
        var swapiStarships = await _starshipsService.GetSwapiStarshipsAsync(starshipsUrl);
        starships.AddRange(swapiStarships.Select(starship => SwapiMapper.Mapper.Map<Starships>(starship)));
    }

    private async Task FillVehiclesAsync(List<string> vehiclesUrl, List<Vehicles> vehicles)
    {
        var swapiVehicles = await _vehiclesService.GetSwapiVehiclesAsync(vehiclesUrl);
        vehicles.AddRange(swapiVehicles.Select(vehicle => SwapiMapper.Mapper.Map<Vehicles>(vehicle)));
    }

    private async Task FillFilmsAsync(List<string> filmsUrl, List<Films> films)
    {
        var swapiFilms = await _filmsService.GetSwapiFilmsAsync(filmsUrl);
        films.AddRange(swapiFilms.Select(film => SwapiMapper.Mapper.Map<Films>(film)));
    }

    private void SaveJsonFile<T>(List<T> objectList, string filename)
    {
        var json = JsonSerializer.Serialize(objectList);
        File.WriteAllText($"jsons/{filename}.json", json);
    }
}