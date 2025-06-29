namespace NameSorter
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Handles writing a list of person names to a file and optionally to the console.
    /// File output is performed via StreamWriter, which is disposed when complete.
    /// </summary>
    internal class NamesWriter(string outputPath) : INamesWriter, IDisposable
    {
        // StreamWriter is opened in overwrite mode. Any I/O errors (file not found,
        // permission denied) will throw and are expected to be handled by the caller.
        private readonly StreamWriter writer = new(outputPath, append: false);

        /// <summary>
        /// Writes each name to the file and optionally echoes it to the console.
        /// Any I/O exceptions during writing are not caught here and will propagate.
        /// </summary>
        public void Write(IEnumerable<IName> names, bool echoToConsole)
        {
            foreach (var person in names)
            {
                var cleanName = string.IsNullOrEmpty(person.Forenames)
                    ? person.Surname
                    : $"{person.Forenames} {person.Surname}";

                if (echoToConsole)
                {
                    Console.WriteLine(cleanName);
                }
                this.writer.WriteLine(cleanName);
            }
        }

        /// <summary>
        /// Flushes the underlying writer to ensure all buffered data is written to disk.
        /// </summary>
        public void Flush()
        {
            this.writer.Flush();
        }

        /// <summary>
        /// Disposes the writer and releases the file handle.
        /// </summary>
        public void Dispose()
        {
            this.writer.Dispose();
        }
    }
}