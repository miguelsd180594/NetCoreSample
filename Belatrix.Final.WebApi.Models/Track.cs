using System;

namespace Belatrix.Final.WebApi.Models
{
    public class Track
    {
        public int TrackId { get; set; }
        public string Name { get; set; }
        public Album Album { get; set; }
        public MediaType MediaType { get; set; }
        public Genre Genre { get; set; }
        public string Composer { get; set; }
        public int MilliSeconds { get; set; }
        public int Bytes { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
