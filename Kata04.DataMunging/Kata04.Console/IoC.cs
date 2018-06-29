using Kata04.DataMunging.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Kata04.Console
{
    public static class IoC
    {
        public static ServiceProvider CongifureServices()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddTransient<IWeatherDataReader, WeatherDataReader>()
                .BuildServiceProvider();

            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            return serviceProvider;
        }
    }
}