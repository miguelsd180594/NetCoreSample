using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Belatrix.Final.WebApi.Models
{
    public class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
        }
        [Key]
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
