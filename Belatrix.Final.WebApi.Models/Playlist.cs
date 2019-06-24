using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Belatrix.Final.WebApi.Models
{
    public class Playlist
    {
        [Key]
        public int PlaylistId { get; set; }
        public string Name { get; set; }
        public ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
}
