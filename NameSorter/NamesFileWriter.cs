namespace NameSorter
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Handles writing a list of names to a file and optionally to the console.
    /// File output is performed via StreamWriter, which is disposed when complete.
    /// </summary>
    internal class NamesFileWriter(string outputPath): INamesFileWriter, IDisposable
    {
        // StreamWriter is opened in overwrite mode. Any I/O errors (file not found,
        // permission denied) will throw and are expected to be handled by the caller.
        private readonly StreamWriter writer = new (outputPath, append: false);

        /// <summary>
        /// Writes each name to the file and optionally echoes it to the console.
        /// Any I/O exceptions during writing are not caught here and will propagate.
        /// </summary>
        /// <param name="names">An IEnumerable of names to write to the file.</param>
        /// <param name="echoToConsole">Whether to also echoe each name to the console.</param>
        public void Write(IEnumerable<IName> names, bool echoToConsole)
        {
            foreach (var name in names)
            {
                var cleanName = string.IsNullOrEmpty(name.Forenames)
                    ? name.Surname
                    : $"{name.Forenames} {name.Surname}";

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