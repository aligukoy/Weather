using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Services
{
    public class UserService: IUserService
    {
        private readonly ILogger<UserService> _logger;


        private readonly IDictionary<string, string> _users = new Dictionary<string, string>
        {
            { AppSettingsManager.Settings[AppSettings.USER_ADMIN], AppSettingsManager.Settings[AppSettings.USER_ADMIN_PASSWORD] },
            
        };

        
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public bool IsValidUserCredentials(string userName, string password)
        {
            _logger.LogInformation($"Validating user [{userName}]");
            return userName == AppSettingsManager.Settings[AppSettings.USER_ADMIN] && password == AppSettingsManager.Settings[AppSettings.USER_ADMIN_PASSWORD];
        }

       
    }
}
