using System.Collections.Generic;
using System.Linq;

namespace Kata04.DataMunging.Application
{
    public static class WeatherDataQuery
    {
        public static int GetDayNumberWithLowestTemperatureSpread(IEnumerable<WeatherData> weatherDataLines)
        {
            return weatherDataLines.OrderBy(line => line.TemperatureSpread).First().DayNumber;
        }
    }
}