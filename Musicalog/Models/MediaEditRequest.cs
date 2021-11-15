using MediaLib.Enums;

namespace Musicalog.Models
{
    /// <summary>
    /// Object for edit media item web post request.
    /// </summary>
    public class MediaEditRequest : MediaRequest
    {
        /// <summary>
        /// The index of the media to edit.
        /// </summary>
        public int Index { get; set; }
    }
}
