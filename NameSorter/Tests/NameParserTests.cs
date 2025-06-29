namespace NameSorter.Tests
{
    using Xunit;

    public class NameParserTests
    {
        private readonly NameParser parser = new();

        [Fact]
        public void Parse_ThrowsArgumentException_WhenInputIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => parser.Parse(string.Empty));
        }

        [Fact]
        public void Parse_ThrowsArgumentException_WhenInputIsWhitespace()
        {
            Assert.Throws<ArgumentException>(() => parser.Parse("   "));
        }

        [Fact]
        public void Parse_ReturnsSurnameOnly_WhenSingleNameProvided()
        {
            var result = parser.Parse("Chewbacca");

            Assert.Null(result.Forenames);
            Assert.Equal("Chewbacca", result.Surname);
        }

        [Fact]
        public void Parse_ReturnsCorrectSplit_WhenTwoNamesProvided()
        {
            // Arrange
            
            // Act
            var result = parser.Parse("Calum Chisholm");

            // Assert
            Assert.Equal("Calum", result.Forenames);
            Assert.Equal("Chisholm", result.Surname);
        }

        [Fact]
        public void Parse_ReturnsCorrectSplit_WhenMultipleNamesProvided()
        {
            // Arrange

            // Act
            // Note that "de Pfeffel" is a good example of a compound name that would break our assumption that
            // would break our parsing logic if it were used as a surname.
            var result = parser.Parse("Alexander Boris de Pfeffel Johnson");

            // Assert
            Assert.Equal("Alexander Boris de Pfeffel", result.Forenames);
            Assert.Equal("Johnson", result.Surname);
        }

        [Fact]
        public void Parse_TrimsExtraSpaces()
        {
            // Arrange

            // Act
            var result = parser.Parse("   Calum Chisholm   ");

            // Assert
            Assert.Equal("Calum", result.Forenames);
            Assert.Equal("Chisholm", result.Surname);
        }

        [Fact]
        public void Parse_IgnoresExtraInternalWhitespace()
        {
            // Arrange

            // Act
            var result = parser.Parse("  Clive   Marles   Sinclair  ");

            // Assert
            Assert.Equal("Clive Marles", result.Forenames);
            Assert.Equal("Sinclair", result.Surname);
        }
    }
}