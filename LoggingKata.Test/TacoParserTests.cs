using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange
            var tester = new TacoParser();
            //Act
            var actual = tester.Parse(line).Location.Longitude;
            //Assert
            Assert.Equal(expected, actual);
        }


        //TODO: Create a test ShouldParseLatitude
        [Theory]
        [InlineData("34.8831, -84.293899, Taco Bell Blue Ridg...", 34.8831)]
        [InlineData("32.484926, -84.935962, Taco Bell Columbus...",32.484926)]
        [InlineData("34.003114, -84.169905, Taco Bell Dulut...", 34.003114)]
         
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            var tester = new TacoParser();

            //Act
            var actual = tester.Parse(line).Location.Latitude;

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
