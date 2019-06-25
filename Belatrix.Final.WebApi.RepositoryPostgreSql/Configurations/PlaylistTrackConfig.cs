using Belatrix.Final.WebApi.Models;
using Belatrix.Final.WebApi.Repository.PostgreSql.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.Final.WebApi.Repository.PostgreSql.Configurations
{
    internal class PlaylistTrackConfig : IEntityTypeConfiguration<PlaylistTrack>
    {
        public void Configure(EntityTypeBuilder<PlaylistTrack> builder)
        {
            builder.ToTable("playlist_track")
                .HasKey(x => new { x.PlaylistId, x.TrackId })
                .HasName("playlist_track_id_pkey");

            builder.Property(x => x.PlaylistId)
                .HasColumnName("PlaylistId".ToLowerWithUnderdash())
                .IsRequired();

            builder.Property(x => x.TrackId)
                .HasColumnName("TrackId".ToLowerWithUnderdash())
                .IsRequired();

            builder.HasOne(x => x.PlayList)
                .WithMany(x => x.PlaylistTracks)
                .HasForeignKey(x => x.PlaylistId)
                .HasConstraintName("playlist_track__reference_playlist__fkey");

            builder.HasOne(x => x.Track)
                .WithMany(x => x.PlaylistTracks)
                .HasForeignKey(x => x.TrackId)
                .HasConstraintName("playlist_track__reference_track__fkey");
        }
    }
}
