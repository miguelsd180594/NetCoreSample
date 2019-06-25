using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Belatrix.Final.WebApi.Models
{
    public class Track
    {
        public Track()
        {
            InvoiceLines = new HashSet<InvoiceLine>();
            PlaylistTracks = new HashSet<PlaylistTrack>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Album Album { get; set; }
        public MediaType MediaType { get; set; }
        public Genre Genre { get; set; }
        public string Composer { get; set; }
        public int MilliSeconds { get; set; }
        public int Bytes { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime InsertDate { get; set; }
        public int AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int GenreId { get; set; }
        public ICollection<InvoiceLine> InvoiceLines { get; set; }
        public ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
}
