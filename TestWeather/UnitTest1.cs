using Microsoft.AspNetCore.Mvc;
using Weather.BusinessLogic;
using Weather.Repository;
using WeatherApi.Controllers;

namespace TestWeather
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            WeatherRepository weatherRepository = new WeatherRepository();
            WeatherService weatherService = new WeatherService(weatherRepository);
            WeatherController weather = new WeatherController(weatherService);

            var result = await weather.GetWeatherForecast("Bangalore", DateTime.Now);
            Assert.NotNull(result);

            var res = result as OkObjectResult;
            Assert.Equal(res.StatusCode,200);
        }


        [Fact]
        public async void BadRequest()
        {
            WeatherRepository weatherRepository = new WeatherRepository();
            WeatherService weatherService = new WeatherService(weatherRepository);
            WeatherController weather = new WeatherController(weatherService);

            var result = await weather.GetWeatherForecast("",default);
            Assert.NotNull(result);

            var res = result as BadRequestObjectResult;
            Assert.Equal(res.StatusCode , 400);
        }

    }
}