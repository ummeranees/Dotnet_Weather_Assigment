
using Weather.Repository.Interface;
using Weather.Repository;
using Weather.BusinessLogic;
using Weather.BusinessLogic.Interface;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.ResponseCompression;

namespace WeatherApi
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddResponseCompression(options =>
            {
                // Add Gzip compression
                options.EnableForHttps = true; // Enable compression for HTTPS connections
                options.Providers.Add<GzipCompressionProvider>();

            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();
            builder.Services.AddScoped<IWeatherService, WeatherService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseResponseCompression();
            app.MapControllers();

            app.Run();
        }
    }
}
