namespace NameSorter
{
    /// <summary>
    /// Represents a person's name, allowing for single names (mononyms) and multiple forenames.
    /// We'll use a record struct to store this - it's lightweight and well-suited to value-type comparisons.
    ///
    /// For our use-case, the struct can be marked as immutable (readonly) and its properties as init-only.
    /// As well as improving the correctness of the code, this may also improve performance.
    /// </summary>
    internal readonly record struct Name : IName
    {
        /// <summary>
        /// An individual's forename(s)
        /// Nullable to accommodate Pelé, Banksy, Ronaldo and Madonna.
        /// </summary>
        public string? Forenames { get; init; }

        /// <summary>
        /// An individual's surname (or possibly only name)
        /// </summary>
        required public string Surname { get; init; }
    }
}