﻿using System.ComponentModel.DataAnnotations;

namespace Belatrix.Final.WebApi.Models
{
    public class PlaylistTrack
    {
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }
        public Playlist PlayList { get; set; }

        public Track Track { get; set; }
    }
}
