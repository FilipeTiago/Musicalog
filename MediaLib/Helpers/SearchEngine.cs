using MediaLib.Interfaces;
using MediaLib.Template;
using System.Collections.Generic;

namespace MediaLib.Helpers
{
    /// <summary>
    /// Search engine. This static class is to handle the search requests given a collection of items and rules.
    /// </summary>
    public static class SearchEngine
    {
        /// <summary>
        /// Search a collection with rules.
        /// </summary>
        /// <param name="data">The data to search.</param>
        /// <param name="rules">The rules to apply</param>
        /// <returns></returns>
        public static IEnumerable<Media> Search(this IEnumerable<dynamic> data, IEnumerable<IMatchRule<Media>> rules)
        {
            var response = new List<Media>();
            foreach (var entry in data)
            {
                bool match = true;
                foreach (var rule in rules)
                    if (!rule.IsMatch(entry)) { match = false; break; }
                if (match) response.Add(entry);
            }
            return response;
        }
    }
}
