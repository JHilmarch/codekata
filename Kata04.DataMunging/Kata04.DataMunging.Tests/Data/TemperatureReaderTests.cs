using System;
using FluentAssertions;
using Kata04.DataMunging.Data;
using Xunit;

namespace Kata04.DataMunging.Tests.Data
{
    public class TemperatureReaderTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ReadTemperature_IsNullOrWhiteSpace_ThrowArgumentException(string temperatureString)
        {
            //Act
            Action action = () => TemperatureReader.ReadTemperature(temperatureString);

            //Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ReadTemperature_IsDoubleWithWhiteSpace_ReturnsTemperature()
        {
            //Act
            var temperature = TemperatureReader.ReadTemperature(" 88 ");

            //Assert
            temperature.Should().Be(88);
        }

        [Fact]
        public void ReadTemperature_IsDoubleWithTrailingStar_ReturnsTemperature()
        {
            //Act
            var temperature = TemperatureReader.ReadTemperature("97.1*");

            //Assert
            temperature.Should().Be(97.1);
        }
    }
}