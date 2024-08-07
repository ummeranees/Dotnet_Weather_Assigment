using Weather.BusinessLogic.Interface;
using Weather.Data;
using Weather.Repository.Interface;

namespace Weather.BusinessLogic
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public async Task<WeatherResponse> GetWeatherAsync(string location, DateTime date)
        {
            try
            {
                // Business logic here
                var weather = await _weatherRepository.GenerateRandomWeatherDataAsync(location, date);
                return weather;
            }
            catch (Exception ex) { throw; }
        }
    }
}
