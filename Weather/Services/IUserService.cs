using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Services
{
    public interface IUserService
    {
        bool IsValidUserCredentials(string userName, string password);
    }
}
