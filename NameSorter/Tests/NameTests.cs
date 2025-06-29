namespace NameSorter.Tests
{
    using Xunit;

    public class NameTests
    {
        [Fact]
        public void CanCreateNameWithForenamesAndSurname()
        {
            // Arrange
            var name = new Name
            {
                Forenames = "John Ronald Reuel",
                Surname = "Tolkien",
            };

            // Act

            //Assert
            Assert.Equal("John Ronald Reuel", name.Forenames);
            Assert.Equal("Tolkien", name.Surname);
        }

        [Fact]
        public void CanCreateNameWithOnlySurname()
        {
            // Arrange
            var name = new Name
            {
                Surname = "Madonna",
            };

            // Act

            // Assert
            Assert.Null(name.Forenames);
            Assert.Equal("Madonna", name.Surname);
        }
    }
}