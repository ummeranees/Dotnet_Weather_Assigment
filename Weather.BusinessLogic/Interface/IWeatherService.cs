using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Data;

namespace Weather.BusinessLogic.Interface
{
    public interface IWeatherService
    {
        Task<WeatherResponse> GetWeatherAsync(string location, DateTime date);
    }
}
