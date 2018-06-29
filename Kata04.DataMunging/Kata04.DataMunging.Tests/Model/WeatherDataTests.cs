using System;
using FluentAssertions;
using Xunit;

namespace Kata04.DataMunging.Tests.Model
{
    public class WeatherDataTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void ConstructWeatherData_DayNumberIsNotPositiveNumber_ThrowsArgumentOutOfRangeException(int dayNumber)
        {
            //Act
            Action action = () => new WeatherData(dayNumber, 0D, 0D);

            //Assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ConstructWeatherData_DayNumberIsPositiveNumber_DayNumberIsSet()
        {
            //Arrange
            const int dayNumber = 3;

            //Act
            var wheatherData = new WeatherData(dayNumber, 0D, 0D);

            //Assert
            wheatherData.DayNumber.Should().Be(dayNumber);
        }

        [Fact]
        public void ConstructWeatherData_WithMaximumTemperature_MaximumTemperatureIsSet()
        {
            //Arrange
            const double maximumTemperature = 13.3;

            //Act
            var wheatherData = new WeatherData(1, maximumTemperature, 0D);
            
            //Assert
            wheatherData.MaximumTemperature.Should().Be(maximumTemperature);
        }

        [Fact]
        public void ConstructWeatherData_WithMinimumTemperature_MinimumTemperatureIsSet()
        {
            //Arrange
            const double minimumTemperature = 13.3;

            //Act
            var wheatherData = new WeatherData(1, 100, minimumTemperature);

            //Assert
            wheatherData.MinimumTemperature.Should().Be(minimumTemperature);
        }

        [Fact]
        public void ConstructWeatherData_WithMaxAndMinTemperature_TemperatureSpreadIsSet()
        {
            //Arrange
            const double maximumTemperature = 15.3;
            const double minimumTemperature = 13.3;

            //Act
            var wheatherData = new WeatherData(1, maximumTemperature, minimumTemperature);

            //Assert
            wheatherData.TemperatureSpread.Should().Be(2);
        }

        [Fact]
        public void ConstructWeatherData_MinimumTemperatureIsHigherThanMaximumTemperature_ThrowsArgumentException()
        {
            //Arrange
            const double maximumTemperature = 15.3;
            const double minimumTemperature = 17.3;

            //Act
            Action action = () => new WeatherData(1, maximumTemperature, minimumTemperature);

            //Assert
            action.Should().Throw<ArgumentException>();
        }
    }
}