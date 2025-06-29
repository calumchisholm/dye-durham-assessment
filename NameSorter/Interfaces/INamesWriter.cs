using System.Collections.Generic;

namespace NameSorter
{
    /// <summary>
    /// Handles writing a list of person names to a file.
    /// </summary>
    public interface INamesWriter : IDisposable
    {
        /// <summary>
        /// Writes each name to the file.
        /// </summary>
        void Write(IEnumerable<IName> names, bool echoToConsole);

        /// <summary>
        /// Flushes the underlying writer to ensure all buffered data is written to disk.
        /// </summary>
        void Flush();
    }
}
