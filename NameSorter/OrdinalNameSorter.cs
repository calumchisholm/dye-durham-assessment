namespace NameSorter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Sorts names by surname first, then by forenames. Uses ordinal (case-sensitive, culture-invariant) comparison.
    /// </summary>
    internal class OrdinalNameSorter : INameSorter
    {
        // Ordinal comparison provides culture-invariant, binary-safe, case-sensitive sorting, ensuring consistent behavior
        // across platforms and locales.
        private static readonly StringComparer Comparer = StringComparer.Ordinal;

        /// <summary>
        /// Sorts a sequence of IName by surname then by forenames.
        /// </summary>
        /// 
        /// <param name="names">A collection of names to sort.</param>
        /// 
        /// <returns>An ordered sequence of names, sorted by surname and then forenames.</returns>
        public IEnumerable<IName> Sort(IEnumerable<IName> names)
        {
            return names
                .OrderBy(n => n.Surname, Comparer)
                .ThenBy(n => n.Forenames, Comparer);
        }
    }
}