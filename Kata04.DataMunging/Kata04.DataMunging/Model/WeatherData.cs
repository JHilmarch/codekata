using System;

namespace Kata04.DataMunging
{
    public class WeatherData
    {
        public WeatherData(int dayNumber, double maximumTemperature, double minimumTemperature)
        {
            if (dayNumber <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(dayNumber));
            }

            if (maximumTemperature < minimumTemperature)
            {
                throw new ArgumentException(
                    $"{nameof(maximumTemperature)} ({maximumTemperature}) is lower than " +
                    $"{nameof(minimumTemperature)} ({minimumTemperature})");
            }

            DayNumber = dayNumber;
            MaximumTemperature = maximumTemperature;
            MinimumTemperature = minimumTemperature;
        }

        public int DayNumber { get; private set; }
        public double MaximumTemperature { get; private set; }
        public double MinimumTemperature { get; private set; }
        public double TemperatureSpread => MaximumTemperature - MinimumTemperature;
    }
}