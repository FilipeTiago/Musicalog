using MediaLib.Enums;
using MediaLib.Interfaces;

namespace MediaLib.Template
{
    /// <summary>
    /// Template for the media items.
    /// Reason being is that the available by default is if stock is bigger then 0. But maybe in some rare cases it might be a diferent rule.
    /// </summary>
    public abstract class Media : IMedia
    {
        /// <inheritdoc/>>
        public abstract string Title { get; set; }
        /// <inheritdoc/>>
        public abstract string Artist { get; set; }
        /// <inheritdoc/>>
        public abstract MediaType Type { get; }
        /// <inheritdoc/>>
        public abstract int Stock { get; set; }
        /// <inheritdoc/>>
        public virtual bool Available => Stock > 0;
    }
}
