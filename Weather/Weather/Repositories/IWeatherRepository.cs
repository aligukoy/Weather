using WeatherAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Model.Models;

namespace WeatherAPI.Repositories
{
    public interface IWeatherRepository
    {
        Task<WeatherEntity> GetCurrentWeather(string placeOrZipCode);

        Task<WeatherEntity> GetForecast(string placeOrZipCode, int forecastDays, int interval = 1);
    }
}
