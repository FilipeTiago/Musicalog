using MediaLib.Enums;
using MediaLib.Template;

namespace MediaLib.Medias
{
    /// <summary>
    /// The CD media type.
    /// </summary>
    public class Cd : Media
    {
        /// <inheritdoc/>>
        public override string Title { get; set; }
        /// <inheritdoc/>>
        public override string Artist { get; set; }
        /// <inheritdoc/>>
        public override MediaType Type => MediaType.Cd;
        /// <inheritdoc/>>
        public override int Stock { get; set; }
    }
}
