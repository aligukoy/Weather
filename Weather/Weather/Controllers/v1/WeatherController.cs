using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Dtos;
using WeatherAPI.Entities;
using WeatherAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Model.Models;

namespace WeatherAPI.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherRepository _weatherRepo;
        private readonly IMapper _mapper;
        


        public WeatherController(
            IWeatherRepository weatherRepo,
            IMapper mapper)
        {
            _weatherRepo = weatherRepo;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("getweather/{placeOrZipCode}", Name = nameof(GetSingleWeather))]
        public async Task<ActionResult> GetSingleWeather(ApiVersion version, string placeOrZipCode)
        {
            
            WeatherEntity weatherItem = await _weatherRepo.GetCurrentWeather(placeOrZipCode);

            if (weatherItem == null)
            {
                return NotFound();
            }

            WeatherDto dto = _mapper.Map<WeatherDto>(weatherItem);
            var response = new Response<WeatherDto>();
            response.Object = dto;
            if (weatherItem.Current == null)
            {
                response.Errored = true;
                response.ErrorMessage = "Invalid placeOrZipCode";
            }

            return Ok(response);
        }

      
    }
}
