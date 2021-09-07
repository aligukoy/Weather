using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.Models;

namespace WeatherAPI.Entities
{
    public class WeatherEntity
    {
        public CurrentWeather Current { get; set; }
        public WeatherLocation Location { get; set; }
        public WeatherRequest Request { get; set; }
        public WeatherForecast Forecast { get; set; }
    }
}
