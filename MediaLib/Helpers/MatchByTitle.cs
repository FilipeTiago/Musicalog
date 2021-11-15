using MediaLib.Interfaces;
using MediaLib.SearchRules;
using MediaLib.Template;

namespace MediaLib.Helpers
{
    /// <summary>
    /// Rules to match a media item by media title.
    /// </summary>
    public class MatchByTitle : IMatchRule<Media>
    {
        /// <inheritdoc/>>
        public dynamic Rule { get; }

        /// <inheritdoc/>>
        public bool IsMatch(Media entry)
        {
            var rule = (StringSearchRule)Rule;
            return rule.ExactMatch? entry.Title.Equals(rule.Text, rule.StringComparison) : entry.Title.Contains(rule.Text, rule.StringComparison);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rule">The rule definition</param>
        public MatchByTitle(StringSearchRule rule)
        {
            Rule = rule;
        }
    }
}
