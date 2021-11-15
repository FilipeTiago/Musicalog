using MediaLib.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicalog.Models
{
    public interface IMediaCollection
    {
        public IEnumerable<Media> List { get; }
        public Media Get(int index);
        public void Add(Media mediaItem);
        public void Delete(Media mediaItem);
        public void Delete(int index);
        public void Edit(int index, Media mediaItem);
        public int IndexOf(Media mediaItem);
    }
}
