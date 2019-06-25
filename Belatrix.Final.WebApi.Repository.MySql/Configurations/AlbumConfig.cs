using Belatrix.Final.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.Final.WebApi.Repository.MySql.Configurations
{
    internal class AlbumConfig : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            //builder.ToTable("album")
            //    .HasKey(c => c.AlbumId)
            //    .HasName("album_id_key");

            builder.Property(e => e.Id)
                .HasColumnName("album_id");

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasMaxLength(160);

            builder.HasIndex(e => e.ArtistId)
                .HasName("idx_fk_artist_id");

            builder.Property(e => e.ArtistId)
                .HasColumnName("artist_id");

            builder.HasOne(d => d.Artist)
                .WithMany(p => p.Albums)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("fk_album_artist");
        }
    }
}
