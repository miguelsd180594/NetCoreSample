using Belatrix.Final.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.Final.WebApi.RepositoryPostgreSql.Configurations
{
    internal class PlaylistTrackConfig : IEntityTypeConfiguration<PlaylistTrack>
    {
        public void Configure(EntityTypeBuilder<PlaylistTrack> builder)
        {
            builder.ToTable("playlist_track")
                .HasKey(c => new { c.PlaylistId, c.TrackId })
                .HasName("playlist_track_id_pkey");

            builder.Property(e => e.AlbumId)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn()
                .IsRequired();

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasMaxLength(160);

            builder.HasIndex(e => e.ArtistId)
                .HasName("album_artist_idx");

            builder.Property(e => e.ArtistId)
                .HasColumnName("artist_id");

            builder.HasOne(d => d.Artist)
                .WithMany(p => p.Albums)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("album__reference_artist__idx");
        }
    }
}
