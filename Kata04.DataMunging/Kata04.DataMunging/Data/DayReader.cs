using System;

namespace Kata04.DataMunging.Data
{
    internal static class DayReader
    {
        internal static int ReadDay(string dayString)
        {
            if (string.IsNullOrWhiteSpace(dayString))
            {
                throw new ArgumentException("Cannot read empty value", nameof(dayString));
            }

            return int.Parse(dayString);
        }
    }
}