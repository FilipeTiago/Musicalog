using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musicalog.EF
{
    public class Media
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Type { get; set; }
        public int Stock { get; set; }
    }
}
