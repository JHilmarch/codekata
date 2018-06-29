using System.Collections.Generic;
using System.IO;

namespace Kata04.DataMunging.Data
{
    public interface IWeatherDataReader
    {
        IEnumerable<WeatherData> ReadLines(Stream stream);
    }
}