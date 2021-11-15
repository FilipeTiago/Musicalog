using System;

namespace MediaLib.SearchRules
{
    /// <summary>
    /// String search rule to be used by the search engine.
    /// </summary>
    public class StringSearchRule
    {
        /// <summary>
        /// The text to be found.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// String comparison rules (case sensitive and cultural rules).
        /// </summary>
        public StringComparison StringComparison { get; set; }

        /// <summary>
        /// Is this a exact or partial match.
        /// </summary>
        public bool ExactMatch { get; set; }
    }
}
