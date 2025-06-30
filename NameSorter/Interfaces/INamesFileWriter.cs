namespace NameSorter
{
    using System.Collections.Generic;

    /// <summary>
    /// Handles writing a list of names to a file.
    /// </summary>
    public interface INamesFileWriter : IDisposable
    {
        /// <summary>
        /// Writes each name to the file.
        /// </summary>
        /// <param name="names">An IEnumerable of names to write to the file.</param>
        /// <param name="echoToConsole">Whether to also echoe each name to the console.</param>
        void Write(IEnumerable<IName> names, bool echoToConsole);

        /// <summary>
        /// Flushes the underlying writer to ensure all buffered data is written to disk.
        /// </summary>
        void Flush();
    }
}
