using System;
using FluentAssertions;
using Kata04.DataMunging.Data;
using Xunit;

namespace Kata04.DataMunging.Tests.Data
{
    public class DayReaderTests
    {
        [Fact]
        public void ReadDay_IndataIsEmpty_ThrowsArgumentException()
        {
            //Act
            Action action = () => DayReader.ReadDay(string.Empty);

            //Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ReadDay_IndataIsNotDigit_ThrowException()
        {
            //Act
            Action action = () => DayReader.ReadDay("mo");

            //Assert
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void ReadDay_IndataIsDigitWithWhiteSpace_ReturnsParsedDay()
        {
            //Act
            var day = DayReader.ReadDay(" 1 ");

            //Assert
            day.Should().Be(1);
        }
    }
}