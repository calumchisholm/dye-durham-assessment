namespace NameSorter
{
    using System.Collections.Generic;

    /// <summary>
    /// Sorts names by surname first, then by forenames.
    /// </summary>
    public interface INameSorter
    {
        /// <summary>
        /// Sorts a sequence of IName by surname then by forenames.
        /// </summary>
        /// <param name="names">A collection of names to sort.</param>
        /// <returns>An ordered sequence of names, sorted by surname and then forenames.</returns>
        IEnumerable<IName> Sort(IEnumerable<IName> names);
    }
}