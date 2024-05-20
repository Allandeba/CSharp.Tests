using AutoMapper;
using StarWars.Swapi.Data.Models.MyTheFourth;
using StarWars.Swapi.Data.Models.Swapi;

namespace StarWars.Swapi.Data.Services
{
    public class StringToDoubleConverter : IValueConverter<string, double>
    {
        public double Convert(string sourceMember, ResolutionContext context)
        {
            return double.TryParse(sourceMember, out double result) ? result : 0;
        }
    }

    public class StringToIntConverter : IValueConverter<string, int>
    {
        public int Convert(string sourceMember, ResolutionContext context)
        {
            return int.TryParse(sourceMember, out int result) ? result : 0;
        }
    }

    public static class SwapiMapper
    {
        private static IMapper _mapper { get; set; } = null!;

        static SwapiMapper() => ConfigureMapper();

        public static IMapper Mapper => _mapper;

        private static void ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PlanetsProfile>();
                cfg.AddProfile<FilmsProfile>();
                cfg.AddProfile<VehiclesProfile>();
                cfg.AddProfile<StarshipsProfile>();
                cfg.AddProfile<PeopleProfile>();
                cfg.AddProfile<SpeciesProfile>();
            });

            _mapper = config.CreateMapper();
        }
    }

    public class PlanetsProfile : Profile
    {
        public PlanetsProfile()
        {
            CreateMap<SwapiPlanetsResult, Planets>()
                .ForMember(dest => dest.RotationPeriod, opt => opt.ConvertUsing(new StringToDoubleConverter()))
                .ForMember(dest => dest.OrbitalPeriod, opt => opt.ConvertUsing(new StringToDoubleConverter()))
                .ForMember(dest => dest.Diameter, opt => opt.ConvertUsing(new StringToDoubleConverter()))
                .ForMember(dest => dest.Films, opt => opt.Ignore())
                .ForMember(dest => dest.Residents, opt => opt.Ignore());
        }
    }

    public class FilmsProfile : Profile
    {
        public FilmsProfile()
        {
            CreateMap<SwapiFilmsResult, Films>()
                .ForMember(dest => dest.Characters, opt => opt.Ignore())
                .ForMember(dest => dest.Species, opt => opt.Ignore())
                .ForMember(dest => dest.Planets, opt => opt.Ignore())
                .ForMember(dest => dest.Vehicles, opt => opt.Ignore())
                .ForMember(dest => dest.Starships, opt => opt.Ignore());
        }
    }

    public class VehiclesProfile : Profile
    {
        public VehiclesProfile()
        {
            CreateMap<SwapiVehiclesResult, Vehicles>()
                .ForMember(dest => dest.Length, opt => opt.ConvertUsing(new StringToDoubleConverter()))
                .ForMember(dest => dest.MaxAtmospheringSpeed, opt => opt.ConvertUsing(new StringToIntConverter()))
                .ForMember(dest => dest.Crew, opt => opt.ConvertUsing(new StringToIntConverter()))
                .ForMember(dest => dest.Passangers, opt => opt.ConvertUsing(new StringToIntConverter()))
                .ForMember(dest => dest.Cargo_capacity, opt => opt.ConvertUsing(new StringToIntConverter()))
                .ForMember(dest => dest.Movies, opt => opt.Ignore())
                .ForMember(dest => dest.Pilots, opt => opt.Ignore());
        }
    }

    public class StarshipsProfile : Profile
    {
        public StarshipsProfile()
        {
            CreateMap<SwapiStarshipsResult, Starships>()
                .ForMember(dest => dest.Length, opt => opt.ConvertUsing(new StringToDoubleConverter()))
                .ForMember(dest => dest.MaxAtmospheringSpeed, opt => opt.ConvertUsing(new StringToIntConverter()))
                .ForMember(dest => dest.Crew, opt => opt.ConvertUsing(new StringToIntConverter()))
                .ForMember(dest => dest.Passangers, opt => opt.ConvertUsing(new StringToIntConverter()))
                .ForMember(dest => dest.Cargo_capacity, opt => opt.ConvertUsing(new StringToIntConverter()))
                .ForMember(dest => dest.HyperdriveRating, opt => opt.ConvertUsing(new StringToDoubleConverter()))
                .ForMember(dest => dest.MGLT, opt => opt.ConvertUsing(new StringToIntConverter()))
                .ForMember(dest => dest.Movies, opt => opt.Ignore())
                .ForMember(dest => dest.Pilots, opt => opt.Ignore());
        }
    }

    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            CreateMap<SwapiPeopleResult, People>()
                .ForMember(dest => dest.Height, opt => opt.ConvertUsing(new StringToDoubleConverter()))
                .ForMember(dest => dest.Mass, opt => opt.ConvertUsing(new StringToDoubleConverter()))
                .ForMember(dest => dest.Homeworld, opt => opt.Ignore())
                .ForMember(dest => dest.Movies, opt => opt.Ignore())
                .ForMember(dest => dest.Species, opt => opt.Ignore())
                .ForMember(dest => dest.Vehicles, opt => opt.Ignore())
                .ForMember(dest => dest.Starships, opt => opt.Ignore());
        }
    }

    public class SpeciesProfile : Profile
    {
        public SpeciesProfile()
        {
            CreateMap<SwapiSpeciesResult, Species>()
                .ForMember(dest => dest.AvarageHeight, opt => opt.ConvertUsing(new StringToIntConverter()))
                .ForMember(dest => dest.AvarageLifespan, opt => opt.ConvertUsing(new StringToIntConverter()))
                .ForMember(dest => dest.Movies, opt => opt.Ignore())
                .ForMember(dest => dest.Homeworld, opt => opt.Ignore())
                .ForMember(dest => dest.People, opt => opt.Ignore());
        }
    }
}