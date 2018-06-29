using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;

namespace Kata04.DataMunging.Data
{
    public class WeatherDataReader : IWeatherDataReader
    {
        private readonly ILogger<WeatherDataReader> _logger;

        public WeatherDataReader(ILogger<WeatherDataReader> logger)
        {
            _logger = logger;
        }

        public IEnumerable<WeatherData> ReadLines(Stream stream)
        {
            var lines = new List<WeatherData>();
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        var weatherData = LineReader.ReadLine(reader);
                        lines.Add(weatherData);
                    }
                    catch (Exception e)
                    {
                        _logger.LogWarning($"Read line failed: {e.Message}");
                    }
                    finally
                    {
                        ReadToEndOfLine(reader);
                    }
                }
            }

            return lines;
        }

        private static void ReadToEndOfLine(StreamReader reader)
        {
            while ((char)reader.Peek() != '\n')
            {
                if (reader.EndOfStream)
                {
                    throw new EndOfStreamException();
                }

                reader.Read();
            }

            reader.Read();
        }
    }
}