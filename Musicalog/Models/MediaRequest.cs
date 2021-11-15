using MediaLib.Enums;

namespace Musicalog.Models
{
    /// <summary>
    /// Object definition media request post.
    /// </summary>
    public class MediaRequest
    {
        /// <summary>
        /// The title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The artist name
        /// </summary>
        public string Artist { get; set; }

        /// <summary>
        /// The media type
        /// </summary>
        public MediaType Type {get; set;}

        /// <summary>
        /// Stock amount.
        /// </summary>
        public int Stock { get; set; }
    }
}
