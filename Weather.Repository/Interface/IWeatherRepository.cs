using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Data;

namespace Weather.Repository.Interface
{
    public interface IWeatherRepository
    {
        Task<WeatherResponse> GenerateRandomWeatherDataAsync(string location, DateTime date);

    }
}
