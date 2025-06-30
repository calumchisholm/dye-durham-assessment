namespace NameSorter
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Contains the entry point for the CLI application.
    /// </summary>
    internal class Program
    {
        private const string OutputFile = "./sorted-names-list.txt";

        /// <summary>
        /// The main application entry point.
        /// </summary>
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("   name-sorter <unsorted-names-list.txt>");
                Environment.Exit((int)ExitCodes.ERROR_ARGS);
            }

            try
            {
                string filePath = args[0];

                INamesFileReader fileReader = new NamesFileReader();
                INameParser parser = new NameParser();

                // We can't assume anything about the culture of the names in our list or the culture of the machine this code
                // will be run on, so we'll perform simple Ordinal comparisons for the sake of simplicity and consistency.
                // This can't be guaranteed to be correct behaviour for all cultures, locales or alphabets, but there's no single
                // (generic) correct approach to this.
                //
                // Sorting will be case-sensitive, so MacDonald will be listed before Macarthur as per convention.
                INameSorter sorter = new NameSorter.OrdinalNameSorter();

                var allNames = new List<IName>();

                foreach (string line in fileReader.ReadLines(filePath))
                {
                    try
                    {
                        // Parse the name and add it to our allNames list.
                        allNames.Add(parser.Parse(line));
                    }
                    // Exceptions are logged to STDERR - these will appear in the console but not redirected by > or | by default.
                    catch (ArgumentException)
                    {
                        Console.Error.WriteLine("[Skipped blank line or whitespace]");
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Error parsing line: {ex.Message}");
                    }
                }

                // Sort the names
                var sortedNames = sorter.Sort(allNames);

                // Open a new writer, creating or (if it already exists) overwriting the output file.
                using (INamesFileWriter writer = new NamesFileWriter(OutputFile))
                {
                    // Write the sorted list of names, also echoing them to the console.
                    writer.Write(sortedNames, true);

                    // Force any buffered data to be written before we terminate.
                    // No need to explicitly call Dispose. The 'using' statement ensures it's disposed when it goes out of scope.
                    writer.Flush();
                }

                // Completed successfully
                Environment.Exit((int)ExitCodes.SUCCESS);
            }
            catch (IOException ex)
            {
                // File IO error. This could be broken down further
                Console.Error.WriteLine($"Error reading file: {ex.Message}");
                Environment.Exit((int)ExitCodes.ERROR_IO);
            }
        }
    }
}