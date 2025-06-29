namespace NameSorter
{
    /// <summary>
    /// Exit codes to return to the operating system on application termination.
    /// </summary>
    internal enum ExitCodes : int
    {
        /// <summary>
        /// Application terminated successfully
        /// </summary>
        SUCCESS = 0,

        /// <summary>
        /// Incorrect command-line arguments
        /// </summary>
        ERROR_ARGS = 1,

        /// <summary>
        /// File I/O errors - file not found, permission errors etc.
        /// </summary>
        ERROR_IO = 2,
    }
}