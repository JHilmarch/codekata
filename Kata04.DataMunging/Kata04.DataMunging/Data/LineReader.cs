using System;
using System.IO;
using System.Text;

namespace Kata04.DataMunging.Data
{
    internal static class LineReader
    {
        internal static WeatherData ReadLine(StreamReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            if (reader.EndOfStream)
            {
                throw new EndOfStreamException();
            }

            SkipWhileWhiteSpaces(reader);
            var dayNumber = ReadDayNumber(reader);

            SkipWhileWhiteSpaces(reader);
            var maxTemperature = ReadTemperature(reader);

            SkipWhileWhiteSpaces(reader);
            var minTemperature = ReadTemperature(reader);

            return new WeatherData(dayNumber, maxTemperature, minTemperature);
        }
    
        private static int ReadDayNumber(StreamReader reader)
        {
            var dayString = ReadToNextWhiteSpace(reader);
            return DayReader.ReadDay(dayString);
        }

        private static double ReadTemperature(StreamReader reader)
        {
            var temperatureString = ReadToNextWhiteSpace(reader);
            return TemperatureReader.ReadTemperature(temperatureString);
        }

        private static string ReadToNextWhiteSpace(StreamReader reader)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append((char) reader.Read());

            while (!char.IsWhiteSpace((char) reader.Peek()))
            {
                if (reader.EndOfStream)
                {
                    throw new EndOfStreamException();
                }

                stringBuilder.Append((char) reader.Read());
            }

            return stringBuilder.ToString();
        }

        private static void SkipWhileWhiteSpaces(StreamReader reader)
        {
            while (char.IsWhiteSpace((char) reader.Peek()))
            {
                if (reader.EndOfStream)
                {
                    throw new EndOfStreamException();
                }

                reader.Read();
            }
        }
    }
}