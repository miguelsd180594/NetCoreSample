using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Belatrix.Final.WebApi.Models
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
