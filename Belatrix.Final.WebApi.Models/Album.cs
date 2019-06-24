using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Belatrix.Final.WebApi.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
