using MediaLib.Interfaces;
using MediaLib.SearchRules;
using MediaLib.Template;

namespace MediaLib.Helpers
{
    /// <summary>
    /// Rules to match a media item by artist name.
    /// </summary>
    public class MatchByArtist : IMatchRule<Media>
    {
        /// <inheritdoc/>>
        public dynamic Rule { get; }

        /// <inheritdoc/>>
        public bool IsMatch(Media entry)
        {
            var rule = (StringSearchRule)Rule;
            return rule.ExactMatch ? entry.Artist.Equals(rule.Text, rule.StringComparison) : entry.Artist.Contains(rule.Text, rule.StringComparison);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rule">The rule definition</param>
        public MatchByArtist(StringSearchRule rule)
        {
            Rule = rule;
        }
    }
}
