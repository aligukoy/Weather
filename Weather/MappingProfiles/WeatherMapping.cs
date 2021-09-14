using AutoMapper;
using WeatherAPI.Dtos;
using WeatherAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.MappingProfiles
{
    public class WeatherMapping : Profile
    {
        public WeatherMapping()
        {
            CreateMap<WeatherEntity, WeatherDto>()
                .ForMember(dest => dest.cloudcover, map => map.MapFrom(src => src.Current.cloudcover))
                .ForMember(dest => dest.feelslike, map => map.MapFrom(src => src.Current.feelslike))
                .ForMember(dest => dest.humidity, map => map.MapFrom(src => src.Current.humidity))
                .ForMember(dest => dest.is_day, map => map.MapFrom(src => src.Current.is_day))
                .ForMember(dest => dest.observation_time, map => map.MapFrom(src => src.Current.observation_time))
                .ForMember(dest => dest.precip, map => map.MapFrom(src => src.Current.precip))
                .ForMember(dest => dest.pressure, map => map.MapFrom(src => src.Current.pressure))
                .ForMember(dest => dest.temperature, map => map.MapFrom(src => src.Current.temperature))
                .ForMember(dest => dest.uv_index, map => map.MapFrom(src => src.Current.uv_index))
                .ForMember(dest => dest.visibility, map => map.MapFrom(src => src.Current.visibility))
                .ForMember(dest => dest.weather_code, map => map.MapFrom(src => src.Current.weather_code))
                .ForMember(dest => dest.weather_descriptions, map => map.MapFrom(src => src.Current.weather_descriptions))
                .ForMember(dest => dest.wind_degree, map => map.MapFrom(src => src.Current.wind_degree))
                .ForMember(dest => dest.wind_dir, map => map.MapFrom(src => src.Current.wind_dir))
                .ForMember(dest => dest.wind_speed, map => map.MapFrom(src => src.Current.wind_speed))
                .ForMember(dest => dest.country, map => map.MapFrom(src => src.Location.country))
                .ForMember(dest => dest.region, map => map.MapFrom(src => src.Location.region))
                .ForMember(dest => dest.name, map => map.MapFrom(src => src.Location.name))
                .ReverseMap();


        }
        
    }
}
