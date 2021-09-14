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

using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using WeatherAPI.Helpers;
using WeatherAPI.Services;

namespace WeatherAPI.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherRepository _weatherRepo;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ISecurityService _securityService;
        
        


        public WeatherController(
            IWeatherRepository weatherRepo,
            IMapper mapper,
            IConfiguration config,
            IUserService userService,
            ISecurityService securityService)
        {
            _weatherRepo = weatherRepo;
            _mapper = mapper;
            _userService = userService;
            _securityService = securityService;
        }

        [AllowAnonymous]
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
                response.ErrorMessage = "Zip Code or Place cannot be found";
            }

            return Ok(response);
        }


        [Authorize]
        [HttpGet]
        [Route("getGoodStuff", Name = nameof(GetGoodStuff))]
        public  ActionResult GetGoodStuff(ApiVersion version)
        {

            GoodStuffEntity goodStuff = GoodStuffEntity.GetGoodStuff(true);

            return Ok(goodStuff);
        }

       




    }
}
