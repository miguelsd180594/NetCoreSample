using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Belatrix.Final.WebApi.Models
{
    public class Playlist
    {
        public Playlist()
        {
            PlaylistTracks = new HashSet<PlaylistTrack>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
}
