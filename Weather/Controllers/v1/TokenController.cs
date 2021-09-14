using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using WeatherAPI.Services;
using System.Security;
using WeatherAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace WeatherAPI.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TokenController: ControllerBase 
    {
        private readonly ISecurityService _securityService;
        private readonly IUserService _userService;
        

        public TokenController(ISecurityService securityService,
            IUserService userService)
        {
            _securityService = securityService;
            _userService = userService;
        }


        [AllowAnonymous]
        [Route("Authenticate")]
        [HttpPost]
        public IActionResult Authenticate([FromBody] User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("Authenticate","Invalid Username or password");
                    return BadRequest(ModelState);
                }

                if ( _userService.IsValidUserCredentials(user.UserName, user.Password))
                {
                    var token = new ObjectResult(this._securityService.GenerateToken(user.UserName));
                    return token;
                }
                    
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new SecurityException(ex.Message);
            }
        }

       
    }
}
