namespace MediaLib.Interfaces
{
    /// <summary>
    /// Interface for search items with a specific rule.
    /// </summary>
    /// <typeparam name="T">The type of object used for matching</typeparam>
    public interface IMatchRule<T>
    {
        /// <summary>
        /// The rule to be used by the search
        /// </summary>
        public dynamic Rule { get; }

        /// <summary>
        /// If the entry item match the given rules.
        /// </summary>
        /// <param name="entry">The entry item to be tested</param>
        /// <returns>Boolean with the match outcome</returns>
        public bool IsMatch(T entry);
    }
}
