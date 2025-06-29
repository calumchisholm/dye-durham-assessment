namespace NameSorter
{
    /// <summary>
    /// Parses a full name into an IName, separating forenames and surname.
    /// </summary>
    public interface INameParser
    {
        /// <summary>
        /// Parses a line of input into an IName instance.
        /// </summary>
        /// 
        /// <param name="input">A single line of text containing a name</param>
        /// 
        /// <returns>An IName struct representing the parsed name</returns>
        IName Parse(string input);
    }
}