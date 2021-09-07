using WeatherAPI.Repositories;
using System.Threading.Tasks;

namespace WeatherAPI.Services
{
    public interface ISeedDataService
    {
        Task Initialize(WeatherDBContext context);
    }
}
