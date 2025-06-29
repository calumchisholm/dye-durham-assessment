namespace NameSorter
{
    /// <summary>
    /// Reads a text file line-by-line into an enumerable sequence of strings.
    /// </summary>
    public interface INamesFileReader
    {
        /// <summary>
        /// Reads all the lines from the specified file and returns them as an enumerable sequence of strings.
        /// </summary>
        /// <param name="filePath">The path to the file to read from.</param>
        /// <returns>An enumerable collection of strings, where each string represents a line in the file.</returns>
        public IEnumerable<string> ReadLines(string filePath);
    }
}