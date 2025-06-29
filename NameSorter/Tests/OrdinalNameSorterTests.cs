namespace NameSorter.Tests
{
    using Xunit;

    public class OrdinalNameSorterTests
    {
        private readonly OrdinalNameSorter sorter;

        public OrdinalNameSorterTests()
        {
            sorter = new OrdinalNameSorter();
        }

        [Fact]
        public void Sort_ShouldSortBySurnameThenForenames()
        {
            // Arrange: Create a list of names to sort
            var names = new List<IName>
            {
                new Name { Surname = "Lennon", Forenames = "John" },
                new Name { Surname = "McCartney", Forenames = "Paul" },
                new Name { Surname = "Harrison", Forenames = "George" },
                new Name { Surname = "Starr", Forenames = "Ringo" }
            };

            // Act: Sort the names using the sorter
            var sortedNames = sorter.Sort(names);

            // Assert: Verify that the names are sorted by surname first, then by forenames
            var sortedList = new List<IName>(sortedNames);
            
            Assert.Equal("Harrison", sortedList[0].Surname);
            Assert.Equal("George", sortedList[0].Forenames);

            Assert.Equal("Lennon", sortedList[1].Surname);
            Assert.Equal("John", sortedList[1].Forenames);

            Assert.Equal("McCartney", sortedList[2].Surname);
            Assert.Equal("Paul", sortedList[2].Forenames);

            Assert.Equal("Starr", sortedList[3].Surname);
            Assert.Equal("Ringo", sortedList[3].Forenames);
        }

        [Fact]
        public void Sort_ShouldHandleEmptyList()
        {
            // Arrange: Empty list of names
            var names = new List<IName>();

            // Act: Sort the empty list
            var sortedNames = sorter.Sort(names);

            // Assert: The result should still be an empty list
            Assert.Empty(sortedNames);
        }

        [Fact]
        public void Sort_ShouldSortCorrectlyWithDifferentCases()
        {
            // Arrange: List of names with different cases, out-of-order.
            var names = new List<IName>
            {
                new Name { Surname = "Lennon", Forenames = "John" },
                new Name { Surname = "lennon", Forenames = "John" },
                new Name { Surname = "lennon", Forenames = "john" },
                new Name { Surname = "Lennon", Forenames = "john" }
            };

            // Act: Sort the names
            var sortedNames = sorter.Sort(names);

            // Assert: Check the sorted order matches the expected case-sensitivity
            var sortedList = new List<IName>(sortedNames);
            Assert.Equal("Lennon", sortedList[0].Surname);
            Assert.Equal("John", sortedList[0].Forenames);

            Assert.Equal("Lennon", sortedList[1].Surname);
            Assert.Equal("john", sortedList[1].Forenames);

            Assert.Equal("lennon", sortedList[2].Surname);
            Assert.Equal("John", sortedList[2].Forenames);

            Assert.Equal("lennon", sortedList[3].Surname);
            Assert.Equal("john", sortedList[3].Forenames);
        }
    }
}