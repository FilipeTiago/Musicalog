using MediaLib.Enums;

namespace MediaLib.Interfaces
{
    /// <summary>
    /// Interface for media item types.
    /// </summary>
    public interface IMedia
    {
        /// <summary>
        /// Title of the media
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The artist name
        /// </summary>
        public string Artist { get; set; }   

        /// <summary>
        /// The type of media. 
        /// </summary>
        public MediaType Type { get; }

        /// <summary>
        /// Number of items in stock
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Is the media available?
        /// </summary>
        public bool Available { get; }

        //This interface will allow in the future to add methods that the media types will implement, for example play a demo or other necessary features for the future.
    }
}
