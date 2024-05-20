using Microsoft.Extensions.DependencyInjection;
using StarWars.Swapi.Data.Services;

// Services
var services = new ServiceCollection();
services.AddScoped<IPlanetsService, PlanetsService>();
services.AddScoped<IFilmsService, FilmsService>();
services.AddScoped<IPeopleService, PeopleService>();
services.AddScoped<ISpeciesService, SpeciesService>();
services.AddScoped<IStarshipsService, StarshipsService>();
services.AddScoped<IVehiclesService, VehiclesService>();
services.AddScoped<ISwapiService, SwapiService>();
var serviceProvider = services.BuildServiceProvider();

var swapiService = serviceProvider.GetRequiredService<ISwapiService>();

await swapiService.SaveAllJsonAsync();