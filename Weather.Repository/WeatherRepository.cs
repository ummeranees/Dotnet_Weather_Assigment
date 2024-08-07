using Weather.Data;
using Weather.Repository.Interface;

namespace Weather.Repository
{
    public class WeatherRepository : IWeatherRepository
    {
        public Task<WeatherResponse> GenerateRandomWeatherDataAsync(string location, DateTime date)
        {
            try
            {
                var random = new Random();
                var weather = new WeatherResponse
                {
                    Main = new WeatherMain
                    {
                        Temp = Math.Round(random.NextDouble() * 10 + 280, 2),
                        Pressure = random.Next(1000, 1020),
                        Humidity = random.Next(30, 90),
                        TempMin = Math.Round(random.NextDouble() * 10 + 278, 2),
                        TempMax = Math.Round(random.NextDouble() * 10 + 282, 2),
                        Visibility = random.Next(1000, 20000),
                        Sunrise = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        Sunset = DateTimeOffset.Now.AddHours(12).ToUnixTimeSeconds(),
                        Description = "clear sky"
                    },
                    Wind = new WeatherWind
                    {
                        Speed = Math.Round(random.NextDouble() * 5, 1),
                        Deg = random.Next(0, 360)
                    },
                    Location = location,
                    Date = date.ToString("yyyy/MM/dd"),
                    DataValidUntil = DateTime.UtcNow.AddHours(2).ToString("o")
                };

                return Task.FromResult(weather);
            }
            catch (Exception ex) { throw; }
        }
    }
}
