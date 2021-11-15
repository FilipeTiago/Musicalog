using MediaLib.Template;
using System.Collections.Generic;

namespace Musicalog.Models
{
    /// <summary>
    /// Media items repository. Latter on when using a database change this.
    /// </summary>
    public class MediaRepository : List<Media>, IMediaCollection
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="items"></param>
        public MediaRepository()
        {
            
        }

        public IEnumerable<Media> List => this;

        public Media Get(int index) => this[index];

        /// <summary>
        /// Add item. Just in case we want to add some logic to this latter on.
        /// </summary>
        /// <param name="mediaItem"></param>
        public new void Add (Media mediaItem)
        {
            this.Add(mediaItem);
        }

        /// <summary>
        /// Delete media item.
        /// </summary>
        /// <param name="mediaItem"></param>
        public void Delete (Media mediaItem)
        {
            this.Remove(mediaItem);
        }

        /// <summary>
        /// Delete media item.
        /// </summary>
        /// <param name="index"></param>
        public void Delete (int index)
        {
            this.RemoveAt(index);
        }

        /// <summary>
        /// Edit media item.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="mediaItem"></param>
        public void Edit (int index, Media mediaItem)
        {
            if (this.Count > index)
            this[index] = mediaItem;
        }

        /// <summary>
        /// What is the index of this media item.
        /// </summary>
        /// <param name="mediaItem"></param>
        /// <returns></returns>
        public new int IndexOf (Media mediaItem)
        {
            return this.IndexOf(mediaItem);
        }
    }
}
