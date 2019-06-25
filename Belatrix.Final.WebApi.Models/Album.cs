using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Belatrix.Final.WebApi.Models
{
    public class Album
    {
        public Album()
        {
            Tracks = new HashSet<Track>();
        }
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
