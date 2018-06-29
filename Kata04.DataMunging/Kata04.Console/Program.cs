using System.IO;
using Kata04.DataMunging.Application;
using Kata04.DataMunging.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Kata04.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = IoC.CongifureServices();
            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            var weatherDataReader = serviceProvider.GetService<IWeatherDataReader>();

            var weatherDataLines = weatherDataReader.ReadLines(File.OpenRead(args[0]));

            var dayWithLowestTemperatureSpread =
                WeatherDataQuery.GetDayNumberWithLowestTemperatureSpread(weatherDataLines);

            logger.LogInformation($"Day {dayWithLowestTemperatureSpread} has lowest temperature spread.");

            System.Console.ReadKey();
        }
    }
}