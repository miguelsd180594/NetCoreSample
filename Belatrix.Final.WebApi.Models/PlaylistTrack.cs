namespace Belatrix.Final.WebApi.Models
{
    public class PlaylistTrack
    {
        public int Id { get; set; }
        public Playlist PlayList { get; set; }

        public Track Track { get; set; }
    }
}
