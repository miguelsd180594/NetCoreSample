using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Belatrix.Final.WebApi.Models
{
    public class MediaType
    {
        public MediaType()
        {
            Tracks = new HashSet<Track>();
        }
        [Key]
        public int MediaTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
