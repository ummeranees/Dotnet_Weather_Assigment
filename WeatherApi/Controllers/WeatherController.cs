using Microsoft.AspNetCore.Mvc;
using System.Net;
using Weather.BusinessLogic.Interface;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherForecast([FromQuery] string location, [FromQuery] DateTime date)
        {
            try
            {
                if (string.IsNullOrEmpty(location) || date == default)
                {
                    return BadRequest("Location and date must be provided.");
                }
                var weather = await _weatherService.GetWeatherAsync(location, date);

                if (weather == null)
                    return NotFound();
                return Ok(weather);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An internal server error occurred. Please try again later.",
                    StackTrace = ex.StackTrace 
                });
            }
        }
    }
}
