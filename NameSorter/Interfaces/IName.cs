namespace NameSorter
{
    /// <summary>
    /// Defines a readonly view of a person's name, supporting both mononyms and full names.
    /// </summary>
    public interface IName
    {
        /// <summary>
        /// An individual's forename(s), or null if mononymous.
        /// </summary>
        string? Forenames { get; }

        /// <summary>
        /// An individual's surname (or only name if mononymous).
        /// </summary>
        string Surname { get; }
    }
}
