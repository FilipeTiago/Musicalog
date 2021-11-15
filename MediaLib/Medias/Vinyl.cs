using MediaLib.Enums;
using MediaLib.Template;

namespace MediaLib.Medias
{
    /// <summary>
    /// The Vinyl media type.
    /// </summary>
    public class Vinyl : Media
    {
        /// <inheritdoc/>>
        public override string Title { get; set; }
        /// <inheritdoc/>>
        public override string Artist { get; set; }
        /// <inheritdoc/>>
        public override MediaType Type => MediaType.Vinyl;
        /// <inheritdoc/>>
        public override int Stock { get; set; }
    }
}
