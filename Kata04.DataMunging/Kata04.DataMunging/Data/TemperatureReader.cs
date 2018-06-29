namespace Kata04.DataMunging.Data
{
    internal static class TemperatureReader
    {
        internal static double ReadTemperature(string temperatureString)
        {
            if (string.IsNullOrWhiteSpace(temperatureString))
            {
                throw new System.ArgumentException("Can not read empty temperature string!", nameof(temperatureString));
            }

            var trimmedTemperature = temperatureString.Trim(' ', '*');

            return double.Parse(trimmedTemperature);
        }
    }
}