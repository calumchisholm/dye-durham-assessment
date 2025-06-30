namespace NameSorter
{
    using System;

    /// <summary>
    /// Parses a full name into a Name, separating forenames and surname.
    /// Handles mononyms (single-word names) and names with one or more forenames.
    /// </summary>
    internal class NameParser : INameParser
    {
        /// <summary>
        /// Parses a line of input into an IName instance.
        /// The final word is treated as the surname; all preceding words are treated as forenames.
        /// </summary>
        /// <param name="input">A single line of text containing a name</param>
        /// <returns>A Name struct representing the parsed name</returns>
        /// <exception cref="ArgumentException">Thrown when input is null, empty, or whitespace</exception>
        /// <exception cref="InvalidOperationException">Defensive fallback if name parts are unexpectedly empty</exception>
        public IName Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input line is empty or whitespace.", nameof(input));
            }

            var parts = input.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            return parts.Length switch
            {
                0 => throw new InvalidOperationException("Unreachable: empty name parts after split."),

                // A mononym - treat as surname only
                1 => new Name
                {
                    Forenames = null,
                    Surname = parts[0],
                },

                // A surname and one or more forenames
                _ => new Name
                {
                    Forenames = string.Join(" ", parts[..^1]),
                    Surname = parts[^1],
                }
            };
        }
    }
}