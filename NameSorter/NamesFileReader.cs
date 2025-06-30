namespace NameSorter
{
    using System;
    using System.IO;

    /// <summary>
    /// Reads a text file line-by-line using deferred execution.
    /// </summary>
    internal class NamesFileReader : INamesFileReader
    {
        /// <summary>
        /// Reads all lines from the specified file as a lazily-evaluated enumerable.
        /// </summary>
        /// <param name="filePath">The path to the text file to read.</param>
        /// <returns>An IEnumerable of strings, each representing a line from the file.</returns>
        /// <exception cref="ArgumentException">Thrown if the file path is null, empty or whitespace.</exception>
        /// <exception cref="FileNotFoundException">Thrown if the specified file does not exist.</exception>
        public IEnumerable<string> ReadLines(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path is null or empty.", nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file does not exist.", filePath);
            }

            return File.ReadLines(filePath);
        }
    }
}
